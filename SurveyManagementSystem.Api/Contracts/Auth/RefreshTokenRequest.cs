namespace SurveyManagementSystem.Api.Contracts.Auth;

public record RefreshTokenRequest
(
    string Token,
    string RefreshToken
);
