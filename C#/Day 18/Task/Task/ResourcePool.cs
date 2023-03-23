using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal class ResourcePool
    {
        internal Queue<Resource> Pool;
        public static int MaxPoolSize { get; } = 5;
        public static int MinPoolSize { get; } = 2;

        public ResourcePool()
        {
            Pool = new Queue<Resource>(MinPoolSize);
            for (int i = 0; i < MinPoolSize; i++) {
                var res = new Resource { Name = $"R{Pool.Count + 1}", OwnerPool = this };
                Pool.Enqueue(res);
            }
        }

        public int PoolSize { get => Pool.Count; }

        internal void AddToPool(Resource R)
        {
            if (R.OwnerPool.Pool.Count < MaxPoolSize)
                R.OwnerPool.Pool.Enqueue(R);
        }

        public Resource GetResource()
        {
            if (Pool.Count > 0)
                return Pool.Dequeue();
            return new Resource() { Name = $"R{Pool.Count + 1}" };
        }
    }
}
