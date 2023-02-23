using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Models
{
    internal abstract class PlayerRole : Player
    {
        public Player Player { get; set; }
        

        public PlayerRole(Player player)
        {
            Player = player;
        }

        public override string Operation()
        {
            if (Player != null)
            {
                return Player.Operation();
            }

            return string.Empty;
        }
    }
}
