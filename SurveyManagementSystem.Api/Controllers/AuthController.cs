using SurveyManagementSystem.Api.Contracts.Auth;

namespace SurveyManagementSystem.Api.Controllers;
[Route("[controller]")]
[ApiController]
public class AuthController(IAuthServices authServices,ILogger<AuthController> logger) : ControllerBase
{
    private readonly IAuthServices _authServices = authServices;
    private readonly ILogger<AuthController> _logger = logger;

    [HttpPost("")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {

        _logger.LogInformation("Logging with email: {email} and password: {password}", request.Email, request.Password);
        var result = await _authServices.GetTokenAsync(request.Email, request.Password, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }


    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var result = await _authServices.GetRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

  
    [HttpPost("revoke-refresh-token")]
    public async Task<IActionResult> RevokeRefreshToken([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var result = await _authServices.RevokeRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);

        return result.IsSuccess ? Ok() : result.ToProblem();
    }


    [HttpPost("register")]
    public async Task<IActionResult> register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
    {
        var result = await _authServices.RegisterAsync(request, cancellationToken);

        return result.IsSuccess ? Ok() : result.ToProblem();
    }

}
