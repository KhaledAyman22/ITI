using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ITI.GrpcDemo.Server.Protos;
using Microsoft.AspNetCore.Authorization;
using static ITI.GrpcDemo.Server.Protos.TrackingService;

namespace ITI.GrpcDemo.Server.Services
{
    public class DeviceTrackingService : TrackingServiceBase
    {
        private readonly ILogger<DeviceTrackingService> logger;

        public DeviceTrackingService(ILogger<DeviceTrackingService> logger)
        {
            this.logger = logger;
        }

        //[Authorize(AuthenticationSchemes = "BasicAuthentication", Roles = "device")]
        public override Task<TrackingResponse> SendMessage(TrackingMessage request, ServerCallContext context)
        {
            if (request.Location is null)
            {
                var status = new Status(StatusCode.InvalidArgument, "Location is null");

                var metadata = new Metadata
                {
                    { "more_info", "Please pass the Location" }
                };

                throw new RpcException(status, metadata);
            }

            logger.LogInformation($"Message Received. DeviceId:{request.DeviceId} | Location: ({request.Location.Lat}, {request.Location.Long}) | speed: {request.Speed}");

            return Task.FromResult(new TrackingResponse { Success = true });
        }

        public override async Task<Empty> KeepAlive(IAsyncStreamReader<PulseMessage> requestStream, ServerCallContext context)
        {
            while(await requestStream.MoveNext())
            {
                logger.LogInformation($"Keep Alive Received: DeviceId: {requestStream.Current.DeviceId} Status: {requestStream.Current.Status}");
            }

            return new Empty();
        }

        public override async Task SubscribeNotification(SubscriptionRequest request, IServerStreamWriter<NotificationMessage> responseStream, ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                await responseStream.WriteAsync(new NotificationMessage
                {
                    Text = $"New Notification For Device {request.DeviceId}: {Guid.NewGuid()}",
                    Stamp = Timestamp.FromDateTime(DateTime.UtcNow)
                });

                await Task.Delay(7000);
            }
        }
    }
}
