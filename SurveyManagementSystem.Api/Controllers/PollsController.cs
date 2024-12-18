﻿namespace SurveyManagementSystem.Api.Controllers;

[ApiVersion(1, Deprecated = true)]
[ApiVersion(2)]
[Route("api/[controller]")]
[ApiController]
public class PollsController : ControllerBase
{

    private readonly IPollService _pollService;

    public PollsController(IPollService pollService) => _pollService = pollService;

    [Authorize]
    [HttpGet("")]
    [HasPermission(Permissions.GetPolls)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        => Ok(await _pollService.GetAllAsync());

    [MapToApiVersion(1)]
    [HttpGet("current")]
    [Authorize(Roles = DefaultRoles.Member.Name)]
    [EnableRateLimiting(RateLimiters.UserLimiter)]
    public async Task<IActionResult> GetCurrentV1(CancellationToken cancellationToken)
    {
        return Ok(await _pollService.GetCurrentAsyncV1(cancellationToken));
    }
    [MapToApiVersion(2)]
    [HttpGet("current")]
    [Authorize(Roles = DefaultRoles.Member.Name)]
    [EnableRateLimiting(RateLimiters.UserLimiter)]
    public async Task<IActionResult> GetCurrentV2(CancellationToken cancellationToken)
    {
        return Ok(await _pollService.GetCurrentAsyncV2(cancellationToken));
    }

    [HttpGet("{id}")]
    [HasPermission(Permissions.GetPolls)]
    public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        var poll = await _pollService.GetAsync(id, cancellationToken);
        return poll.IsSuccess ? Ok(poll.Value) : poll.ToProblem();
    }

    [HttpPost("")]
    [HasPermission(Permissions.AddPolls)]
    public async Task<IActionResult> Add([FromBody] PollRequest request, CancellationToken cancellationToken)
    {
        var result = await _pollService.AddAsync(request, cancellationToken);

        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value) : result.ToProblem();
    }

    [HttpPut("{id}")]
    [HasPermission(Permissions.UpdatePolls)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PollRequest request, CancellationToken cancellationToken)
    {
        var poll = await _pollService.UpdateAsync(id, request, cancellationToken);
        return poll.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = poll.Value.Id }, poll.Value) : poll.ToProblem();
    }

    [HttpPut("toggle-status/{id}")]
    [HasPermission(Permissions.UpdatePolls)]
    public async Task<IActionResult> ToggleStatus([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _pollService.ToggleStatusAsync(id, cancellationToken);
        return result.IsSuccess ? Ok() : result.ToProblem();
    }

    [HttpDelete("{id}")]
    [HasPermission(Permissions.DeletePolls)]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _pollService.DeleteAsync(id, cancellationToken);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}