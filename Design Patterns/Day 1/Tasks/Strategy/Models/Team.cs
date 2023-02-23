using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Interfaces;

namespace StrategyPattern.Models
{
    internal class Team
    {
        public ITeamStrategy Strategy { get; set; }

        public List<Player> Players { get; init; }

        public Team() { }

        public Team(ITeamStrategy strategy) { Strategy = strategy; }

        public string PlayGame()
        {
            return Strategy.Play();
        }
    }
}
