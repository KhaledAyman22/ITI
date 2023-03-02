using DP_D02.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_D02.Factory
{
    ///Concerete Factory
    internal class WilliamsCarFactory : ICarFactory
    {
        public Engine CreateEngine() => new MercEngine();

        public FrontWing CreateFrontWing() => new FrontWing01();

        public GearBox CreateGearBox() => new CompanyA();
    }
}
