using SurveyManagementSystem.Api.Contracts.Auth;

namespace SurveyManagementSystem.Api.Services;

public interface IAuthServices
{
    Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellationToken);

    Task<Result<AuthResponse>> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken);
    Task<Result> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken);

}
