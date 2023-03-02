using DP_D02.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_D02.Factory
{
    ///Define an Interface for creating families of Product
    public interface ICarFactory
    {
        ///3 Factory Methods
        Engine CreateEngine();
        GearBox CreateGearBox();
        FrontWing CreateFrontWing();
    }



}
