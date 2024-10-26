using Microsoft.Extensions.Options;
using SurveyManagementSystem.Api.Settings;
using Telegram.Bot;

namespace SurveyManagementSystem.Api.Services
{
    public class TelegramBotService : ITelegramBotService
    {
        private readonly TelegramBotClient _botClient;
        private readonly ILogger<TelegramBotService> _logger;

        public TelegramBotService(IOptions<TelegramBotSettings> options,ILogger<TelegramBotService> logger)
        {
            var token = options?.Value?.Token ?? throw new ArgumentNullException(nameof(options), "Bot token is required.");
            _botClient = new TelegramBotClient(token);
            _logger = logger;
        }

        public async Task<bool> SendMessageAsync(string message, string? chatId = null)
        {
            try
            {
                var targetChatId = chatId ?? await GetChatIdAsync();
                await _botClient.SendTextMessageAsync(chatId: targetChatId, text: message);
                return true;
            }
            catch (Exception ex)
            {
              _logger.LogError(ex, "Failed to send message");
                return false;
            }
        }

        public async Task<string> GetChatIdAsync()
        {
            var updates = await _botClient.GetUpdatesAsync();
            var latestUpdate = updates?.LastOrDefault();

            return latestUpdate?.Message?.Chat.Id.ToString()
                   ?? throw new Exception("No recent messages to retrieve chat ID.");
        }
    }
}
