namespace SurveyManagementSystem.Api.Services;

public class PollService : IPollService
{
    private readonly ApplicationDbContext _context;

    public PollService(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<PollResponse>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _context.Polls.AsNoTracking().ProjectToType<PollResponse>().ToListAsync(cancellationToken);

    public async Task<IEnumerable<PollResponse>> GetCurrentAsync(CancellationToken cancellationToken = default) =>
      await _context.Polls
          .Where(x => x.IsPublished && x.StartsAt <= DateOnly.FromDateTime(DateTime.UtcNow) && x.EndsAt >= DateOnly.FromDateTime(DateTime.UtcNow))
          .AsNoTracking()
          .ProjectToType<PollResponse>()
          .ToListAsync(cancellationToken);


    public async Task<Result<PollResponse>> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var poll = await _context.Polls.FindAsync(id, cancellationToken);

        return poll is not null
            ? Result.Success(poll.Adapt<PollResponse>())
            : Result.Failure<PollResponse>(PollErrors.PollNotFound);
    }


    public async Task<Result<PollResponse>> AddAsync(PollRequest request, CancellationToken cancellationToken = default)
    {
        if (await _context.Polls.AnyAsync(x => x.Title == request.Title, cancellationToken))
            return Result.Failure<PollResponse>(PollErrors.DuplicatedPollTitle);


        var poll = request.Adapt<Poll>();
        await _context.AddAsync(poll, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(poll.Adapt<PollResponse>());
    }

    public async Task<Result<PollResponse>> UpdateAsync(int id, PollRequest request, CancellationToken cancellationToken = default)
    {
        if (await _context.Polls.AnyAsync(x => x.Title == request.Title && x.Id != id, cancellationToken))
            return Result.Failure<PollResponse>(PollErrors.DuplicatedPollTitle);

        var poll = await _context.Polls.FindAsync(id, cancellationToken);

        if (poll is null)
            return Result.Failure<PollResponse>(PollErrors.PollNotFound);

        request.Adapt(poll);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success<PollResponse>(poll.Adapt<PollResponse>());

    }

    public async Task<Result> ToggleStatusAsync(int id, CancellationToken cancellationToken = default)
    {
        var poll = await _context.Polls.FindAsync(id, cancellationToken);

        if (poll is null)
            return Result.Failure(PollErrors.PollNotFound);

        poll.IsPublished = !poll.IsPublished;

        await _context.SaveChangesAsync(cancellationToken);

        //TODO
        //Send email when it be published

        return Result.Success();

    }

    public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var poll = await _context.Polls.FindAsync(id, cancellationToken);

        if (poll is null)
            return Result.Failure(PollErrors.PollNotFound);

        _context.Polls.Remove(poll);

        await _context.SaveChangesAsync(cancellationToken);


        return Result.Success();

    }



}