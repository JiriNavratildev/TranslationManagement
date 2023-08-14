namespace TranslationManagement.Application.Notifications;

public interface INotificationService
{
    Task SendNotificationAsync(string text);
}