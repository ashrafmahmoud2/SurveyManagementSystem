namespace SurveyManagementSystem.Api.Services;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

public class EmailService : IEmailService
{
    //usenig https://app.mailjet.com/account/apikeys;
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var apiKey = _configuration["Mailjet:ApiKey"];
        var apiSecret = _configuration["Mailjet:SecretKey"];
        var senderEmail = _configuration["Mailjet:SenderEmail"];
        var senderName = _configuration["Mailjet:SenderName"];

        MailjetClient client = new MailjetClient(apiKey, apiSecret);
        MailjetRequest request = new MailjetRequest
        {
            Resource = Send.Resource,
        }
        .Property(Send.FromEmail, senderEmail)
        .Property(Send.FromName, senderName)
        .Property(Send.Subject, subject)
        .Property(Send.HtmlPart, body)
        .Property(Send.Recipients, new JArray {
                new JObject {
                    {"Email", toEmail}
                }
        });

        MailjetResponse response = await client.PostAsync(request);

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
