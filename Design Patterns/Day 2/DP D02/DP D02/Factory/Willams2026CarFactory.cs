using DP_D02.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_D02.Factory
{
    /// <summary>
    /// Open for Extension
    /// </summary>
    public class Willams2026CarFactory : ICarFactory
    {
        public Engine CreateEngine() => new FordEngine();


        public FrontWing CreateFrontWing() => new FrontWing01();

        public GearBox CreateGearBox() => new CompanyB();
    }
}
