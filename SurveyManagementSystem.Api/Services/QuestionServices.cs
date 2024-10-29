using Microsoft.Extensions.Caching.Hybrid;
using SurveyManagementSystem.Api.Abstractions;
using SurveyManagementSystem.Api.Contracts.Common;
using SurveyManagementSystem.Api.Contracts.Question;
using System.Linq.Dynamic.Core;

namespace SurveyManagementSystem.Api.Services;

public class QuestionServices(ApplicationDbContext context,HybridCache hybridCache) : IQuestionServices
{
    private readonly ApplicationDbContext _context = context;
    private readonly HybridCache _hybridCache = hybridCache;

    private const string _cachePrefix = "availableQuestions";

    public async Task<Result<PaginatedList<QuestionResponse>>> GetAllAsync(int pollId, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var pollIsExists = await _context.Polls.AnyAsync(x => x.Id == pollId, cancellationToken: cancellationToken);

        if (!pollIsExists)
            return Result.Failure<PaginatedList<QuestionResponse>>(PollErrors.PollNotFound);

        var query = _context.Questions
            .Where(x => x.PollId == pollId);

        if (!string.IsNullOrEmpty(filters.SearchValue))
        {
            query = query.Where(x => x.Content.Contains(filters.SearchValue));
        }

        if (!string.IsNullOrEmpty(filters.SortColumn))
        {
            query = query.OrderBy($"{filters.SortColumn} {filters.SortDirection}");
        }

        var source = query
                        .Include(x => x.Answers)
                        .ProjectToType<QuestionResponse>()
                        .AsNoTracking();

        var questions = await PaginatedList<QuestionResponse>.CreateAsync(source, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(questions);
    }

    public async Task<Result<IEnumerable<QuestionResponse>>> GetAvailableAsync(int pollId, string userId, CancellationToken cancellationToken = default)
    {
        var hasVote = await _context.Votes.AnyAsync(x => x.PollId == pollId && x.UserId == userId, cancellationToken);

        if (hasVote)
            return Result.Failure<IEnumerable<QuestionResponse>>(VoteErrors.DuplicatedVote);

        var pollIsExists = await _context.Polls.AnyAsync(x => x.Id == pollId && x.IsPublished
        && x.StartsAt <= DateOnly.FromDateTime(DateTime.UtcNow) &&
        x.EndsAt >= DateOnly.FromDateTime(DateTime.UtcNow),
        cancellationToken);

        if (!pollIsExists)
            return Result.Failure<IEnumerable<QuestionResponse>>(PollErrors.PollNotFound);

        var cacheKey = $"{_cachePrefix}-{pollId}";

        var questions = await _hybridCache.GetOrCreateAsync<IEnumerable<QuestionResponse>>(
                   cacheKey,
                   async cacheEntry => await _context.Questions
                       .Where(x => x.PollId == pollId && x.IsActive)
                       .Include(x => x.Answers)
                       .Select(q => new QuestionResponse(
                          q.Id,
                           q.Id,
                           q.Content,
                           q.Answers.Where(a => a.IsActive).Select(a => new Contracts.Answer.AnswerResponse(a.Id, a.Content))
                       ))
                       .AsNoTracking()
                       .ToListAsync(cancellationToken)
               );

        return Result.Success(questions!);
    }

    public async Task<Result<QuestionResponse>> GetAsync(int pollId, int questionId, CancellationToken cancellationToken = default)
    {
        var pollExists = await _context.Polls.AnyAsync(x => x.Id == pollId, cancellationToken);

        if (!pollExists)
            Result.Failure<QuestionResponse>(PollErrors.PollNotFound);

        var question = await _context
       .Questions
       .Where(x => x.Id == questionId && x.PollId == pollId && x.IsActive && x.PollId == pollId)
      // .ProjectToType<QuestionResponse>()
      .Select(q => new QuestionResponse(
          q.PollId,
                    q.Id,
                    q.Content,
                    q.Answers.Where(a => a.IsActive).Select(a => new Contracts.Answer.AnswerResponse(a.Id, a.Content))
                ))
       .AsNoTracking()
       .SingleOrDefaultAsync(cancellationToken);


        return question is null ? Result.Failure<QuestionResponse>(QuestionErrors.QuestionNotFound) : Result.Success(question!);

    }

    public async Task<Result<QuestionResponse>> AddAsync(int pollId, QuestionRequest request, CancellationToken cancellationToken = default)
    {
        var pollIsExists = await _context.Polls.AnyAsync(x => x.Id == pollId, cancellationToken: cancellationToken);

        if (!pollIsExists)
            return Result.Failure<QuestionResponse>(PollErrors.PollNotFound);

        var questionIsExists = await _context.Questions.AnyAsync(x => x.Content == request.Content && x.PollId == pollId, cancellationToken: cancellationToken);

        if (questionIsExists)
            return Result.Failure<QuestionResponse>(QuestionErrors.DuplicatedQuestionContent);

        var question = request.Adapt<Question>();
        question.PollId = pollId;

        await _context.AddAsync(question, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        await _hybridCache.RemoveAsync($"{_cachePrefix}-{pollId}", cancellationToken);

        return Result.Success(question.Adapt<QuestionResponse>());

    }

    public async Task<Result<QuestionResponse>> UpdateAsync(int pollId, int questionId, QuestionRequest request, CancellationToken cancellationToken = default)
    {
        var pollExisist = await _context.Polls.AnyAsync(x => x.Id == pollId, cancellationToken);

        if (!pollExisist)
            return Result.Failure<QuestionResponse>(PollErrors.PollNotFound);


        var QuestionExists = await _context.Questions.AnyAsync(
           x => x.Id == pollId
           && x.Id != questionId
           && x.Content == request.Content,
            cancellationToken);

        if (QuestionExists)
            return Result.Failure<QuestionResponse>(QuestionErrors.DuplicatedQuestionContent);


        var question = await _context.Questions
           .Include(x => x.Answers)
            .SingleOrDefaultAsync(x => x.PollId == pollId && x.Id == questionId, cancellationToken);

        if (question is null)
            return Result.Failure<QuestionResponse>(QuestionErrors.QuestionNotFound);

        question.Content = request.Content;


        // current answers
        var currentAnswers = question.Answers.Select(x => x.Content).ToList();

        //new Answers in request not in Db
        var newAnswers = request.Answers.Except(currentAnswers).ToList(); //Except method in C# is used to find the set difference between two collections.

        foreach (var answerContent in newAnswers)
        {
            question.Answers.Add(new Answer { Content = answerContent });
        }


        question.Answers.ToList().ForEach(answer =>
        {
            answer.IsActive = request.Answers.Contains(answer.Content);
            //Contains:determine whether a collection contains a specific element.
        });

        await _context.SaveChangesAsync(cancellationToken);
        await _hybridCache.RemoveAsync($"{_cachePrefix}-{pollId}", cancellationToken);

        return Result.Success(question.Adapt<QuestionResponse>());
    }

    public async Task<Result> ToggleStatusAsync(int pollId, int questionId, CancellationToken cancellationToken = default)
    {
        var question = await _context.Questions.SingleOrDefaultAsync(x => x.PollId == pollId && x.Id == questionId, cancellationToken);

        if (question is null)
            return Result.Failure(QuestionErrors.QuestionNotFound);

        question.IsActive = !question.IsActive;

        await _context.SaveChangesAsync(cancellationToken);

        await _hybridCache.RemoveAsync($"{_cachePrefix}-{pollId}", cancellationToken);

        return Result.Success();
    }



}
