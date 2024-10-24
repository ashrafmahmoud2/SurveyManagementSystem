using SurveyManagementSystem.Api.Contracts.Email;

[ApiController]
[Route("[controller]")]
//public class EmailController : ControllerBase
//{
//    private readonly IEmailService _emailService;

//    public EmailController(IEmailService emailService)
//    {
//        _emailService = emailService;
//    }

//    [HttpPost("send")]
//    public async Task<IActionResult> SendEmail([FromBody] EmailRequest emailRequest)
//    {
//        await _emailService.SendEmailAsync(emailRequest.ToEmail, emailRequest.Subject, emailRequest.Body);
//        return Ok("Email sent successfully!");
//    }
//}

public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("send-email")]
    public async Task<IActionResult> SendEmail([FromBody]EmailRequest request)
    {
        await _emailService.SendEmailAsync(request.ToEmail, request.Subject, request.Body);
        return Ok("Email sent.");
    }
}

