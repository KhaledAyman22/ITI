using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcePool
{
    public static class RscPool
    {
        internal static Queue<Resource> Pool;
        public static int MaxPoolSize { get; } = 5;
        public static int MinPoolSize { get; } = 2;

        ///Create instead of Ctor
        static RscPool()
        {
            Pool = new Queue<Resource>(MinPoolSize);
            for (int i = 0; i < MinPoolSize; i++)
                Pool.Enqueue(new Resource { Name = $"R{Pool.Count + 1}" });
        }


        public static int PoolSize { get => Pool.Count; }

        internal static void AddToPool(Resource R)
        {
            if (Pool.Count < MaxPoolSize)
                Pool.Enqueue(R);
        }

        public static Resource GetResource()
        {
            if (Pool.Count > 0)
                return Pool.Dequeue();
            return new Resource() { Name = $"R{Pool.Count + 1}" };
        }

    }
}
