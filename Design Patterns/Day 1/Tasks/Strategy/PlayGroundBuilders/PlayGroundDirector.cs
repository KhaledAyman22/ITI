using StrategyPattern.Interfaces;

namespace StrategyPattern.PlayGroundBuilders
{
    internal class PlayGroundDirector
    {
        public IPlayGroundBuilder builder { get; set; }

        public void BuildPlayGround()
        {
            builder.BuildAudience();
            builder.BuildGallery();
            builder.BuildGroundSurface();
            builder.BuildGroundAppearance();
        }
    }
}
