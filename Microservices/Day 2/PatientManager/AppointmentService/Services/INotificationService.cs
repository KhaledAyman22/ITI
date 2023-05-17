namespace AppointmentService.Services
{
    public interface INotificationService
    {
        Task Send(NotificationMessage message);
    }
}