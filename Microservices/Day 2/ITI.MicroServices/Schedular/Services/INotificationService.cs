namespace Schedular.Services
{
    public interface INotificationService
    {
        Task Send(NotificationMessage message);
    }
}