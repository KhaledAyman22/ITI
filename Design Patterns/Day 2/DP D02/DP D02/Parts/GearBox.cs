using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_D02.Parts
{
    /// <summary>
    /// Abstract Product B
    /// </summary>
    public abstract class GearBox
    {
        public abstract int Gears { get; }
        public abstract string Title { get; }

    }

    ///Concrete Product B1
    public class CompanyA : GearBox
    {
        public override int Gears => 8;

        public override string Title => "Company A";
    }

    public class CompanyB : GearBox
    {
        public override int Gears => 7;

        public override string Title => "Company B";
    }

}
