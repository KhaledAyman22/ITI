using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Interfaces;

namespace StrategyPattern.TeamStrategies
{
    internal class DefenceStrategy : ITeamStrategy
    {
        public string Play()
        {
            return "Switch to defence strategy.";
        }
    }
}
