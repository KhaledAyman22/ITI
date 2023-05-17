using Azure.Messaging.ServiceBus;
using System.Text.Json;

namespace AppointmentService.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ServiceBusSender serviceBusSender;

        public NotificationService(ServiceBusSender serviceBusSender)
        {
            this.serviceBusSender = serviceBusSender;
        }

        public async Task Send(NotificationMessage message)
        {
            await serviceBusSender.SendMessageAsync(new ServiceBusMessage(
                JsonSerializer.Serialize(message)));
        }
    }
}
