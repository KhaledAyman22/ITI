using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StrategyPattern.Models
{
    internal class PlayGround
    {
        public List<object> parts { get; }

        public void Add(object obj)
        {
            parts.Add(obj);
        }

        public PlayGround()
        {
            parts = new();
        }
    }
}
