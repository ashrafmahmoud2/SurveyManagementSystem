using System.ComponentModel.DataAnnotations;

namespace SurveyManagementSystem.Api.Settings;

public class EmailSettings
{

    public const string SectionName = "Mailjet";
    [Required] public string ApiKey { get; set; } = string.Empty;
    [Required] public string SecretKey { get; set; } = string.Empty;
    [Required, EmailAddress] public string SenderEmail { get; set; } = string.Empty;
    [Required] public string SenderName { get; set; } = string.Empty;
}
