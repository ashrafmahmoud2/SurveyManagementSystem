using System.ComponentModel.DataAnnotations;

namespace SurveyManagementSystem.Api.Contracts.Email;

public class EmailSettings
{

    public const string SectionName = "EmailSettings"; // Changed to const
    [Required]
    public string SmtpServer { get; set; } = string.Empty;

    [Required]
    public int SmtpPort { get; set; }

    [Required]
    public string Username { get; set; } = string.Empty; // Changed from Email to Username

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required]
    public string FromEmail { get; set; } = string.Empty;

    [Required]
    public string FromName { get; set; } = string.Empty;
}
