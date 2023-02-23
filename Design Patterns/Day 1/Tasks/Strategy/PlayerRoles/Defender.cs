using StrategyPattern.Models;

namespace StrategyPattern.PlayerRoles
{
    internal class Defender : PlayerRole
    {
        public Defender(Player player) : base(player)
        {
        }

        public override string Operation()
        {
            return $"Defend at ({Direction.X}, {Direction.Y}), {base.Operation()}";
        }
    }
}