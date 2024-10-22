using SurveyManagementSystem.Api.Contracts.Question;

namespace SurveyManagementSystem.Api.Controllers;
[Route("api/polls/{pollId}/[controller]")]
[ApiController]
[Authorize]
public class QuestionsController(IQuestionServices questionServices) : ControllerBase
{

    private readonly IQuestionServices _questionServices = questionServices;

    [HttpGet("")]
    public async Task<IActionResult> GetAll([FromRoute] int pollId, CancellationToken cancellationToken)
    {
        var result = await _questionServices.GetAllAsync(pollId, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }


    [HttpGet("{questionId}")]
    public async Task<IActionResult> Get([FromRoute] int pollId, [FromRoute] int questionId, CancellationToken cancellationToken)
    {
        var result = await _questionServices.GetAsync(pollId, questionId, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }


    [HttpPost("")]
    public async Task<IActionResult> Add([FromRoute] int pollId, [FromBody] QuestionRequest request, CancellationToken cancellationToken)
    {
        var result = await _questionServices.AddAsync(pollId, request, cancellationToken);

        return result.IsSuccess ? CreatedAtAction(nameof(Get), new { pollId, result.Value.QuestionId }, result.Value) : result.ToProblem();
    }


    [HttpPut("{questionId}")]
    public async Task<IActionResult> Update([FromRoute] int pollId, [FromRoute] int questionId, [FromBody] QuestionRequest request, CancellationToken cancellationToken)
    {

        var result = await _questionServices.UpdateAsync(pollId, questionId, request, cancellationToken);

        return result.IsSuccess ? CreatedAtAction(nameof(Get), new { pollId, result.Value.QuestionId }, result.Value) : result.ToProblem();
    }


    [HttpPut("toggle-status/{questionId}")]
    public async Task<IActionResult> ToggleStatus([FromRoute] int pollId, [FromRoute] int questionId, CancellationToken cancellationToken)
    {

        var result = await _questionServices.ToggleStatusAsync(pollId, questionId, cancellationToken);

        return result.IsSuccess ? NoContent() : result.ToProblem();
    }


}
