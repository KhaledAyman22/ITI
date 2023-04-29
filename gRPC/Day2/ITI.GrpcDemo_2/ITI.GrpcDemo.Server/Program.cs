
using ITI.GrpcDemo.Server.Services;
using Microsoft.AspNetCore.Authentication;

namespace ITI.GrpcDemo.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
            builder.Services.AddCors(opt => opt.AddPolicy("All", 
                b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
                .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding")));


            // Add services to the container.
            builder.Services.AddAuthorization();

            const string scheme = "BasicAuthentication";

            builder.Services.AddAuthentication(scheme)
                            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(scheme, opt => { });


            builder.Services.AddGrpc();
            builder.Services.AddGrpcReflection();

            var app = builder.Build();

            app.UseCors();

            app.UseAuthorization();
            app.UseAuthentication();

            // Configure the HTTP request pipeline.
            app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
            
            app.MapGrpcReflectionService();
            app.MapGrpcService<DeviceTrackingService>().RequireCors("All");
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}