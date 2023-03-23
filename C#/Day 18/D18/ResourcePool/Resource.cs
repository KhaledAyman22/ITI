using System.Threading.Channels;

namespace ResourcePool
{
    ///Creation of Resource Time Consuming
    public class Resource:IDisposable
    {
        public required string Name { get; init; }

        public void UseResource() => Console.WriteLine($"Using Resource {Name} ....");

        public void Dispose()
        {
            RscPool.AddToPool( this );
        }

        internal Resource()
        {
            Console.WriteLine( $"Creating Resource {Name} Started ....");
            Thread.Sleep( 2500 );
            Console.WriteLine($"Creating Resource {Name} Ended");

        }

    }
}