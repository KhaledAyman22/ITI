namespace ITI.GrpcDemo.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Device Id:");
            int deviceId = int.Parse(Console.ReadLine());

            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddHostedService<Worker>(provider =>
                    {
                        var logger = provider.GetService<ILogger<Worker>>();
                        return new Worker(logger, deviceId);
                    });
                })
                .Build();

            host.Run();
        }
    }
}