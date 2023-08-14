using External.ThirdParty.Services;
using INotificationService = TranslationManagement.Application.Notifications.INotificationService;

namespace TranslationManagement.Infrastructure.Notifications;

public class UNSNotificationService : INotificationService
{
    private const int RetryCount = 100;

    public async Task SendNotificationAsync(string text)
    {
        var unreliableNotificationService = new UnreliableNotificationService();
        Exception error;
        
        for (var i = 0; i < RetryCount; i++)
        {
            try
            {
                var successful = await unreliableNotificationService.SendNotification(text);
                if (successful)
                {
                    return;
                }
            }
            catch (Exception e)
            {
                error = e;
            }
        }
        
        // LOG ERROR HERE, BUT DO NOT THROW EXCEPTION
    }
}