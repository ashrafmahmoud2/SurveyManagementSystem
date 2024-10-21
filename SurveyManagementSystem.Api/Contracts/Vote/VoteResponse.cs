namespace SurveyManagementSystem.Api.Contracts.Vote;

public record VoteResponse
(
  int PollId,
    string PollTitle,
    int VoteId,
    IEnumerable<QuestionAnswerResponse> QuestionAnswers
);
