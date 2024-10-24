namespace SurveyManagementSystem.Api.Contracts.Email;

public record EmailRequest
(string ToEmail, string Subject, string Body);

