using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using SurveyManagementSystem.Api.Settings;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyManagementSystem.Api.HealthChecks
{
    public class MailProviderHealthCheck : IHealthCheck
    {
        private readonly EmailSettings _emailSettings;
        private readonly IEmailService _emailService;

        public MailProviderHealthCheck(IOptions<EmailSettings> emailSettings, IEmailService emailService)
        {
            _emailSettings = emailSettings.Value;
            _emailService = emailService;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken)
        {
            try
            {
                await _emailService.SendEmailAsync("omm68096@gmail.com", "Check Health of email", "");

                return HealthCheckResult.Healthy("Email service is healthy.");
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy("Email service is unhealthy.", ex);
            }
        }
    }
}
