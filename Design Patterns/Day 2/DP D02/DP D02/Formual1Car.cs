using DP_D02.Factory;
using DP_D02.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_D02
{
    ///Closed for Modificaions
    ///Final Product , Assembled Prodect
    public class Formual1Car
    {
        ///Parts
        Engine Engine;
        FrontWing FrontWing;
        GearBox GearBox;

        ICarFactory factory;

        public Formual1Car(ICarFactory carFactory) => factory = carFactory;

        public void Assemble ()
        {
            Engine = factory.CreateEngine();
            FrontWing = factory.CreateFrontWing();
            GearBox = factory.CreateGearBox();

            Console.WriteLine(  "Car Assembled");
        }

        public override string ToString()
            => $"{Engine.EngineManufacture} , {Engine.HoursePower} , {FrontWing.FinNumber} , " +
            $"{FrontWing.DesignType} , {GearBox.Title} , {GearBox.Gears}";

    }
}
