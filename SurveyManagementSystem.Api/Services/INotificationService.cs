namespace SurveyManagementSystem.Api.Services;

public interface INotificationService
{
    Task SendNewPollsNotification(int? pollId = null);
}
