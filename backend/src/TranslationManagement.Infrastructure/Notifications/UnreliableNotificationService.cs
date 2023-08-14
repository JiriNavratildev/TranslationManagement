using TranslationManagement.Application.Notifications;

namespace TranslationManagement.Infrastructure.Notifications;

public class UnreliableNotificationService : INotificationService
{
    private const int RetryCount = 100;

    public async Task SendNotificationAsync(string text)
    {
        for (var i = 0; i < RetryCount; i++)
        {
            try
            {
                // USE EXTERNAL CONNECTOR
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        // WHEN NOTIFICATION IS NOT SEND, JUST STORE IT IN THE LOG
    }
}