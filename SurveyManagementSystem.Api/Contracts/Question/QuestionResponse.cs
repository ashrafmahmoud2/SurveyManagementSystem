
using SurveyManagementSystem.Api.Contracts.Answer;

namespace SurveyManagementSystem.Api.Contracts.Question;

public record QuestionResponse
(
    int PollId,
    int QuestionId,
    string Content,
    IEnumerable<AnswerResponse> Answers
   
);


