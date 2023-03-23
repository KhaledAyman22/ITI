//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ResourcePool
//{
//    public static class RscPool
//    {
//        internal static Queue<Resource> Pool = new();

//        public static int PoolSize { get => Pool.Count; }

//        internal static void AddToPool (Resource R)
//        {
//            Pool.Enqueue (R);
//        }

//        public static Resource GetResource()
//        {
//            if (Pool.Count > 0)
//                return Pool.Dequeue();
//            return new Resource() { Name = $"R{Pool.Count + 1}" };
//        }

//    }
//}
