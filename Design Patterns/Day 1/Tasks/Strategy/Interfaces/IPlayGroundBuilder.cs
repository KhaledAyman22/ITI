using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Interfaces
{
    internal interface IPlayGroundBuilder
    {
        void BuildGallery();
        void BuildGroundSurface();
        void BuildAudience();
        void BuildGroundAppearance();
    }
}
