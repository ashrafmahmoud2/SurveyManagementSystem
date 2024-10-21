using SurveyManagementSystem.Api.Contracts.Vote;

namespace SurveyManagementSystem.Api.Services;

public interface IVoteService
{
    Task<Result<VoteResponse>> AddAsync(int pollId, string userId, VoteRequest request, CancellationToken cancellationToken = default);}
