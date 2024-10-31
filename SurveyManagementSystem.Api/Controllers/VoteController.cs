namespace SurveyManagementSystem.Api.Controllers;


[Route("api/polls/{pollId}/[controller]")]
[ApiController]
[Authorize(Roles = DefaultRoles.Member.Name)]
[EnableRateLimiting(RateLimiters.Concurrency)]
public class VoteController(IVoteService voteService, IQuestionServices questionServices) : ControllerBase
{


    private readonly IVoteService _voteService = voteService;
    private readonly IQuestionServices _questionServices = questionServices;

    [HttpPost("")]
    public async Task<IActionResult> Add([FromRoute] int pollId, [FromBody] VoteRequest request, CancellationToken cancellationToken)
    {
        var result = await _voteService.AddAsync(pollId, User.GetUserId()!, request, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();

    }

    [HttpGet("")]
    public async Task<IActionResult> Start([FromRoute] int pollId, CancellationToken cancellationToken)
    {

        var result = await _questionServices.GetAvailableAsync(pollId, User.GetUserId()!, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();

    }

}
