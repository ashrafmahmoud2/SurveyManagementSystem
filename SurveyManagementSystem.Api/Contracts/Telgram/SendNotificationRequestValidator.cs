namespace SurveyManagementSystem.Api.Contracts.Telgram;

public class SendNotificationRequestValidator : AbstractValidator<SendNotificationRequest>
{
    public SendNotificationRequestValidator()
    {
        RuleFor(x => x.Message)
            .NotEmpty();

        RuleFor(x => x.ChatId)
            .NotEmpty();
    }
}
