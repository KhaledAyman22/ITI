using StrategyPattern.Interfaces;
using StrategyPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.PlayGroundBuilders
{
    internal class PlayGroundBuilder : IPlayGroundBuilder
    {
        private PlayGround playGround;

        public PlayGroundBuilder()
        {
            playGround = new();
        }

        public void BuildAudience()
        {
            playGround.Add("Audience");
        }

        public void BuildGallery()
        {
            playGround.Add("Gallery");
        }

        public void BuildGroundAppearance()
        {
            playGround.Add("GroundAppearance");
        }

        public void BuildGroundSurface()
        {
            playGround.Add("GroundSurface");
        }
    }
}
