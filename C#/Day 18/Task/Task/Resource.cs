using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal class Resource
    {
        public ResourcePool OwnerPool { get; init; }

        public required string Name { get; init; }

        public void UseResource() => Console.WriteLine($"Using Resource {Name} ....");

        public void Dispose()
        {
            OwnerPool.AddToPool(this);
        }

        internal Resource()
        {
            Console.WriteLine($"Creating Resource {Name}, Hash: {this.GetHashCode()} Started ....");
            Thread.Sleep(500);
            Console.WriteLine($"Creating Resource {Name} Ended");
        }
    }
}
