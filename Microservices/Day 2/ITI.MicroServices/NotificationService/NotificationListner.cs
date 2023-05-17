using Azure.Messaging.ServiceBus;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService
{
    public class NotificationListner : ICommunicationListener
    {
        private ServiceBusClient client;
        private ServiceBusProcessor processor;

        public async Task<string> OpenAsync(CancellationToken cancellationToken)
        {
            client = new ServiceBusClient("Endpoint=sb://itidemo.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ZWM2IYWJzoxV+G4LxYc1ykYOQj9BrAUhy+ASbEWVUgg=");

            processor = client.CreateProcessor("notificationqueue");

            processor.ProcessMessageAsync += Processor_ProcessMessageAsync;
            processor.ProcessErrorAsync += Processor_ProcessErrorAsync;

            await processor.StartProcessingAsync(cancellationToken);

            return "Started!";
        }


        private Task Processor_ProcessMessageAsync(ProcessMessageEventArgs arg)
        {
            var message = arg.Message.Body.ToObjectFromJson<NotificationMessage>();

            // Send Notification

            return Task.CompletedTask;
        }
        private Task Processor_ProcessErrorAsync(ProcessErrorEventArgs arg)
        {
            return Task.CompletedTask;
        }

        public async Task CloseAsync(CancellationToken cancellationToken)
        {
            await processor.DisposeAsync().ConfigureAwait(false);
            await client.DisposeAsync().ConfigureAwait(false);
        }

        public void Abort()
        {
            CloseAsync(CancellationToken.None).Wait();
        }

    }
}
