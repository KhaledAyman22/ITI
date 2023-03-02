using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_D02.Parts
{
    public abstract class FrontWing
    {
        public abstract int FinNumber { get; }
        public abstract string DesignType { get; }
    }

    public class FrontWing01 : FrontWing
    {
        public override int FinNumber => 5;

        public override string DesignType => "High Down force";
    }
}
