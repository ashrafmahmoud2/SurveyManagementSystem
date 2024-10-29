namespace SurveyManagementSystem.Api.Contracts.Polls;

public record PollResponseV2
(int Id,
 string Title,
 string Summary,
 DateTime StartAt,
 DateTime EndAt
);

