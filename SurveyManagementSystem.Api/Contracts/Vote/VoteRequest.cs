namespace SurveyManagementSystem.Api.Contracts.Vote;

public record VoteRequest
(
   IEnumerable<VoteAnswerRequest> Answers
);
