using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Models
{
    internal class GameEngine
    {
        public List<Game> Games { get; }

        public GameEngine()
        {
            Games = new();
        }
    }
}
