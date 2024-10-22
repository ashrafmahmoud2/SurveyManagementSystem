namespace SurveyManagementSystem.Api.Services;

public class VoteService(ApplicationDbContext context) : IVoteService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<PollVotesResponse>> AddAsync(int pollId, string userId, VoteRequest request, CancellationToken cancellationToken = default)
    {
        var hasVote = await _context.Votes.AnyAsync(x => x.PollId == pollId && x.UserId == userId, cancellationToken);
        if (hasVote)
            return Result.Failure<PollVotesResponse>(VoteErrors.DuplicatedVote);



        var pollIsExists = await _context.Polls.AnyAsync(x => x.Id == pollId && x.IsPublished && x.StartsAt <= DateOnly.FromDateTime(DateTime.UtcNow)
       && x.EndsAt >= DateOnly.FromDateTime(DateTime.UtcNow), cancellationToken);
        if (!pollIsExists)
            return Result.Failure<PollVotesResponse>(PollErrors.PollNotFound);


        var availableQuestions = await _context.Questions
            .Where(x => x.PollId == pollId && x.IsActive)
            .Select(x => x.Id)
            .ToListAsync(cancellationToken);

        if (!request.Answers.Select(x => x.QuestionId).SequenceEqual(availableQuestions))
            return Result.Failure<PollVotesResponse>(VoteErrors.InvalidQuestion);
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


        var pollVotes = await _context.Polls
            .Where(x => x.Id == pollId)
            .Select(x => new PollVotesResponse(
                x.Title,
                x.Votes.Select(v =>
                    new VoteResponse(
                        $"{v.User.FirstName} {v.User.LastName}",
                        v.SubmittedOn,
                        v.VoteAnswers.Select(a =>
                            new QuestionAnswerResponse(a.Answer.Content, a.Question.Content)
                        ).ToList()
                    )
                ).ToList()
            ))
            .SingleOrDefaultAsync(cancellationToken);


        return Result.Success(pollVotes!);

    }
}
