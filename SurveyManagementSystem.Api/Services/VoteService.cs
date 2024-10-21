using SurveyManagementSystem.Api.Contracts.Vote;

namespace SurveyManagementSystem.Api.Services;

public class VoteService(ApplicationDbContext context) : IVoteService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<VoteResponse>> AddAsync(int pollId, string userId, VoteRequest request, CancellationToken cancellationToken = default)
    {
        var hasVote = await _context.Votes.AnyAsync(x => x.PollId == pollId && x.UserId == userId, cancellationToken);
        if (hasVote)
            return Result.Failure<VoteResponse>(VoteErrors.DuplicatedVote);



        var pollIsExists = await _context.Polls.AnyAsync(x => x.Id == pollId && x.IsPublished && x.StartsAt <= DateOnly.FromDateTime(DateTime.UtcNow)
       && x.EndsAt >= DateOnly.FromDateTime(DateTime.UtcNow), cancellationToken);
        if (!pollIsExists)
            return Result.Failure<VoteResponse>(PollErrors.PollNotFound);


        var availableQuestions = await _context.Questions
            .Where(x => x.PollId == pollId && x.IsActive)
            .Select(x => x.Id)
            .ToListAsync(cancellationToken);

        if (!request.Answers.Select(x => x.QuestionId).SequenceEqual(availableQuestions))
            return Result.Failure<VoteResponse>(VoteErrors.InvalidQuestion);
        //SequenceEqual method compares two sequences (collections) element by element to check if they contain the same elements in the same order.


        var vote = new Vote
        {
            PollId = pollId,
            UserId = userId,
            VoteAnswers = request.Answers.Adapt<IEnumerable<VoteAnswer>>().ToList()

        };
        var voteAnswer = request.Adapt<VoteAnswer>();
        voteAnswer.VoteId = vote.Id;


        await _context.Votes.AddAsync(vote, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        //start
        var poll = await _context.Polls
            .Where(x => x.Id == pollId)
            .Select(x => new { x.Id, x.Title })
            .FirstOrDefaultAsync(cancellationToken);

        var questions = await _context.Questions
            .Where(q => availableQuestions.Contains(q.Id))
            .Select(q => new { q.Id, q.Content })
            .ToListAsync(cancellationToken);

        var answers = await _context.Answers
           .Where(a => request.Answers.Select(r => r.AnswerId).Contains(a.Id))
           .Select(a => new { a.Id, a.Content })
           .ToListAsync(cancellationToken);

        var voteResponse = new VoteResponse(
         poll.Id,
         poll.Title,
         vote.Id,
         request.Answers.Select(answer => new QuestionAnswerResponse(
             questions.First(q => q.Id == answer.QuestionId).Content,
             answers.First(a => a.Id == answer.AnswerId).Content
         ))
     );




        return Result.Success(voteResponse);

    }
}
