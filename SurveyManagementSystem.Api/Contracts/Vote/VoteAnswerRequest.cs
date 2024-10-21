namespace SurveyManagementSystem.Api.Contracts.Vote;

public record VoteAnswerRequest
(
    int QuestionId,
    int AnswerId
);
