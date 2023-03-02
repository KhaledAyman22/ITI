using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Models;

namespace StrategyPattern.PlayerRoles
{
    internal class GoalKeeper : Player
    {
        public override string Operation()
        {
            return $"Pass ball to ({Direction.X}, {Direction.Y})";
        }
    }
}
