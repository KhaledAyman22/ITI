using StrategyPattern.Models;

namespace StrategyPattern.PlayerRoles
{
    internal class Midfielder : PlayerRole
    {
        public Midfielder(Player player) : base(player)
        {
        }

        public override string Operation()
        {
            return $"Dribble to ({Direction.X}, {Direction.Y}), {base.Operation()}";
        }
    }
}
