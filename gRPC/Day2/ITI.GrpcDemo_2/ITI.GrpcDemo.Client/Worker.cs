using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using ITI.GrpcDemo.Server.Protos;
using System.Text;
using static ITI.GrpcDemo.Server.Protos.TrackingService;

namespace ITI.GrpcDemo.Client
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly int deviceId;

        public Worker(ILogger<Worker> logger, int deviceId)
        {
            _logger = logger;
            this.deviceId = deviceId;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7105");
            var client = new TrackingServiceClient(channel);

            var random = new Random();
            Task keepAliveTask = KeepAlive(client, stoppingToken);
            Task notificationTask = SubscribeNotification(client, stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                    var trackingMessage = new TrackingMessage
                    {
                        DeviceId = deviceId,
                        Location = new Location
                        {
                            Lat = random.NextDouble(),
                            Long = random.NextDouble()
                        },
                        Speed = random.Next(0, 250),
                        Stamp = Timestamp.FromDateTime(DateTime.UtcNow)
                    };

                    trackingMessage.Sensors.Add(new Sensor { Name = "SeatBelt", Value = 1 });

                    string token = "device:P@ssw0rd";
                    var bytes = Encoding.UTF8.GetBytes(token);
                    string encodedString = Convert.ToBase64String(bytes);

                    var headers = new Metadata
                    {
                        { "Authorization", $"Basic {encodedString}" }
                    };

                    var trackingResponse = await client.SendMessageAsync(trackingMessage, headers);

                    _logger.LogInformation($"Received Response = {trackingResponse.Success}");

                    await Task.Delay(1000, stoppingToken);
                }
                catch(RpcException ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }

            await Task.WhenAll(keepAliveTask, notificationTask);
        }

        private async Task SubscribeNotification(TrackingServiceClient client, CancellationToken stoppingToken)
        {
            await Task.Run(async() =>
            {
                using var stream = client.SubscribeNotification(new SubscriptionRequest { DeviceId = deviceId });

                while (await stream.ResponseStream.MoveNext(stoppingToken))
                {
                    _logger.LogInformation($"Notification Received: {stream.ResponseStream.Current.Text}");
                }
            });
        }

        private async Task KeepAlive(TrackingServiceClient client, CancellationToken stoppingToken)
        {
            await Task.Run(async () =>
            {
                using var stream = client.KeepAlive();

                while (!stoppingToken.IsCancellationRequested)
                {
                    await stream.RequestStream.WriteAsync(new PulseMessage
                    {
                        DeviceId = deviceId,
                        Status = DeviceStatus.Working,
                        Stamp = Timestamp.FromDateTime(DateTime.UtcNow)
                    });

                    await Task.Delay(5000);
                }
            });
        }
    }
}