using Microsoft.AspNetCore.Mvc;
using SurveyManagementSystem.Api.Contracts.Telgram;
using SurveyManagementSystem.Api.Services;

namespace SurveyManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly ITelegramBotService _telegramBotService;

        public NotificationController(ITelegramBotService telegramBotService)
        {
            _telegramBotService = telegramBotService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] SendNotificationRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.ChatId) || string.IsNullOrWhiteSpace(request.Message))
                return BadRequest("Invalid request parameters.");

            return await _telegramBotService.SendMessageAsync(request.Message, request.ChatId)
                ? Ok("Message sent successfully.")
                : StatusCode(500, "Failed to send the message.");
        }
    }
}
