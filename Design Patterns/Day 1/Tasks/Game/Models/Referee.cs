using StrategyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Models
{
    internal class Referee : IObserver
    {
        private Point direction;
        public Point Direction { get => direction; }

        public void FollowBall(Point point)
        {
            direction = point;
            WriteLine($"Referee {this.GetHashCode()}, is following the ball at ({direction.X},{direction.Y})");
        }

        public void Update(ISubject subject)
        {
            FollowBall((subject as Ball).Position);
        }
    }
}
