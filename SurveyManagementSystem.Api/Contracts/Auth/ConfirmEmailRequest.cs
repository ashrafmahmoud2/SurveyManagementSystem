namespace SurveyManagementSystem.Api.Contracts.Auth;

public record ConfirmEmailRequest
(
   string UserId,
   string Code
 );
