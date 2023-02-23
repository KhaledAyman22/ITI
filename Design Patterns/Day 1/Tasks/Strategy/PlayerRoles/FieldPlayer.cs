using System.Drawing;
using StrategyPattern.Models;

namespace StrategyPattern.PlayerRoles
{
    internal class FieldPlayer : Player
    {
        public override string Operation()
        {
            return $"Pass ball to ({Direction.X}, {Direction.Y})";
        }
    }
}
