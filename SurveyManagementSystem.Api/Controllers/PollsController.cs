namespace SurveyManagementSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PollsController : ControllerBase
{
    public IActionResult GetAll()
    {
        return Ok("Ending");
    }
}
