public interface ITelegramBotService
{

    Task<bool> SendMessageAsync(string message, string? chatId = null);

    Task<string> GetChatIdAsync();
}
