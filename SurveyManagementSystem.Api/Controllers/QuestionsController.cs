using SurveyManagementSystem.Api.Abstractions.Const;
using SurveyManagementSystem.Api.Authentication.Filters;
using SurveyManagementSystem.Api.Contracts.Question;

namespace SurveyManagementSystem.Api.Controllers;
[Route("api/polls/{pollId}/[controller]")]
[ApiController]
[Authorize]
public class QuestionsController(IQuestionServices questionServices) : ControllerBase
{

    private readonly IQuestionServices _questionServices = questionServices;

    [HttpGet("")]
    [HasPermission(Permissions.GetQuestions)]
    public async Task<IActionResult> GetAll([FromRoute] int pollId, CancellationToken cancellationToken)
    {
        var result = await _questionServices.GetAllAsync(pollId, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }


    [HttpGet("{questionId}")]
    [HasPermission(Permissions.GetQuestions)]
    public async Task<IActionResult> Get([FromRoute] int pollId, [FromRoute] int questionId, CancellationToken cancellationToken)
    {
        var result = await _questionServices.GetAsync(pollId, questionId, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }


    [HttpPost("")]
    [HasPermission(Permissions.AddQuestions)]
    public async Task<IActionResult> Add([FromRoute] int pollId, [FromBody] QuestionRequest request, CancellationToken cancellationToken)
    {
        var result = await _questionServices.AddAsync(pollId, request, cancellationToken);

        return result.IsSuccess ? CreatedAtAction(nameof(Get), new { pollId, result.Value.QuestionId }, result.Value) : result.ToProblem();
    }


    [HttpPut("{questionId}")]
    [HasPermission(Permissions.UpdateQuestions)]
    public async Task<IActionResult> Update([FromRoute] int pollId, [FromRoute] int questionId, [FromBody] QuestionRequest request, CancellationToken cancellationToken)
    {

        var result = await _questionServices.UpdateAsync(pollId, questionId, request, cancellationToken);

        return result.IsSuccess ? CreatedAtAction(nameof(Get), new { pollId, result.Value.QuestionId }, result.Value) : result.ToProblem();
    }


    [HttpPut("toggle-status/{questionId}")]
    [HasPermission(Permissions.UpdateQuestions)]
    public async Task<IActionResult> ToggleStatus([FromRoute] int pollId, [FromRoute] int questionId, CancellationToken cancellationToken)
    {

        var result = await _questionServices.ToggleStatusAsync(pollId, questionId, cancellationToken);

        return result.IsSuccess ? NoContent() : result.ToProblem();
    }


}
