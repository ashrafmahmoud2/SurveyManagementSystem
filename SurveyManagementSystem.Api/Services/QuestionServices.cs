using Azure.Core;
using SurveyManagementSystem.Api.Contracts.Answer;
using SurveyManagementSystem.Api.Contracts.Auth;
using SurveyManagementSystem.Api.Contracts.Question;
using SurveyManagementSystem.Api.Entities;
using SurveyManagementSystem.Api.Entitles;
using System.Linq;

namespace SurveyManagementSystem.Api.Services;

public class QuestionServices(ApplicationDbContext context) : IQuestionServices
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<IEnumerable<QuestionResponse>>> GetAllAsync(int pollId, CancellationToken cancellationToken = default)
    {
        var pollExists = await _context.Polls.AnyAsync(x => x.Id == pollId, cancellationToken);

        if (!pollExists)
            Result.Failure<QuestionResponse>(PollErrors.PollNotFound);

        var questions = await _context.Questions
            .Where(x => x.IsActive && x.PollId == (pollId))
            .Include(x => x.Answers)  // Eager load the related answers
            .AsNoTracking()
            //.Select(q => new QuestionResponse
            //(
            //    q.Id,
            //    q.PollId,
            //    q.Content,
            //    q.Answers.Select(a => new AnswerResponse(a.Id, a.Content)).ToList()  // Project to AnswerResponse
            //))
            .ProjectToType<QuestionResponse>() //ProjectToType will do all the comment code
            .ToListAsync(cancellationToken);

        return Result.Success<IEnumerable<QuestionResponse>>(questions);
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
        var pollExists = await _context.Polls.AnyAsync(x => x.Id == pollId, cancellationToken);

        if (!pollExists)
            return Result.Failure<QuestionResponse>(PollErrors.PollNotFound);

        var QuestionExists = await _context.Questions.AnyAsync(x => x.PollId == pollId && x.Content == request.Content, cancellationToken);

        if (QuestionExists)
            return Result.Failure<QuestionResponse>(QuestionErrors.DuplicatedQuestion);

        var question = request.Adapt<Question>();
        question.PollId = pollId;
        // we add answer by using mappster in MappingConfigurations.cs


        await _context.Questions.AddAsync(question, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

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
            return Result.Failure<QuestionResponse>(QuestionErrors.DuplicatedQuestion);


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

        return Result.Success(question.Adapt<QuestionResponse>());
    }

    public async Task<Result> ToggleStatusAsync(int pollId, int questionId, CancellationToken cancellationToken = default)
    {
        var pollExists = await _context.Polls.AnyAsync(x => x.Id == pollId, cancellationToken);
        if (!pollExists)
            return Result.Failure(PollErrors.PollNotFound);

        var question = await _context.Questions.SingleOrDefaultAsync(x => x.Id == questionId && x.PollId == pollId, cancellationToken);
        if (question is null)
            return Result.Failure(QuestionErrors.QuestionNotFound);

        question.IsActive = !question.IsActive;

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }



}
