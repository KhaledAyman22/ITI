using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_D02.Parts
{
    ///Abstract ProductA
    public abstract class Engine
    {
        public abstract string EngineManufacture { get;  }

        public abstract int HoursePower { get; }
    }

    ///Concrete Product A1
    class MercEngine : Engine
    {
        public override string EngineManufacture => "Merc";
        public override int HoursePower => 1500;
    }


    ///Concrete Product A2
    class HondaEngine : Engine
    {
        public override string EngineManufacture => "Honda";
        public override int HoursePower => 1650;
    }

    ///Concrete Product A3
    class FerrariEngine : Engine
    {
        public override string EngineManufacture => "Ferrari";
        public override int HoursePower => 1450;
    }

    ///Open for Extension
    ///Concerete Product A4
    class FordEngine : Engine
    {
        public override string EngineManufacture => "Ford";

        public override int HoursePower => 1900;
    }
}
