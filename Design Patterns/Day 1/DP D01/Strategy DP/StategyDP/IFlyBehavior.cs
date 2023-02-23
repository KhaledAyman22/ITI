using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_DP.StategyDP
{
    public interface IFlyBehavior
    {
        void PerformFly();
    }

    public class NormalFly : IFlyBehavior
    {
        public void PerformFly() => Console.WriteLine("Fly Normal Speed");
    }

    public class NoFly : IFlyBehavior
    {
        public void PerformFly() => Console.WriteLine("No Wings to Fly");
    }

    /// <summary>
    /// Open for Extension
    /// </summary>
    public class FlyRocketSpeed : IFlyBehavior
    {
        public void PerformFly() => Console.WriteLine("Fly Rocket Speed");
    }

}
