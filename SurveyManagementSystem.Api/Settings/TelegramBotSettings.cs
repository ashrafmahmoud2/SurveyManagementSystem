using System.ComponentModel.DataAnnotations;

namespace SurveyManagementSystem.Api.Settings
{
    public  class TelegramBotSettings
    {
        [Required]
        public  string Token { get; set; } = string.Empty;
    }
}
