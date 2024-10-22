namespace SurveyManagementSystem.Api.Services;

public interface IVoteService
{
    Task<Result<PollVotesResponse>> AddAsync(int pollId, string userId, VoteRequest request, CancellationToken cancellationToken = default);
}
