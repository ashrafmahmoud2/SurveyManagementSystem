namespace SurveyManagementSystem.Api.Services;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SurveyManagementSystem.Api.Settings;
using System.Threading.Tasks;
public class EmailService : IEmailService
{
    // Using in email Api https://app.mailjet.com/account/apikeys

    private readonly EmailSettings _emailSettings;

    public EmailService(IOptions<EmailSettings> options)
    {
        _emailSettings = options.Value;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var client = new MailjetClient(_emailSettings.ApiKey, _emailSettings.SecretKey);

        var request = new MailjetRequest
        {
            Resource = Send.Resource,
        }
        .Property(Send.FromEmail, _emailSettings.SenderEmail)
        .Property(Send.FromName, _emailSettings.SenderName)
        .Property(Send.Subject, subject)
        .Property(Send.HtmlPart, body)
        .Property(Send.Recipients, new JArray {
            new JObject { { "Email", toEmail } }
        });

        var response = await client.PostAsync(request);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Email sent successfully.");
        }
        else
        {
            Console.WriteLine($"Error sending email: {response.StatusCode}\n{response.GetData()}");
        }
    }
}
