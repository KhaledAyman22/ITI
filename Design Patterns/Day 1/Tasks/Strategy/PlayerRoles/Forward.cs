using System.Drawing;
using StrategyPattern.Models;

namespace StrategyPattern.PlayerRoles
{
    internal class Forward : PlayerRole
    {
        public Forward(Player player) : base(player)
        {
        }

        public override string Operation()
        {
            return $"Shoot ball to ({Direction.X}, {Direction.Y}), {base.Operation()}";
        }
    }
}
