using StrategyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Models
{
    internal abstract class Player : IObserver
    {
        private Point direction;
       
        public Point Direction { get => direction; set { direction = value; } }

        public Player()
        {
            Direction= new Point(1,1);
        }
        
        public void FollowBall(Point point)
        {
            direction = point;

            WriteLine($"Player {this.GetHashCode()}, is following the ball at ({direction.X},{direction.Y})");
        }

        public abstract string Operation();

        public void Update(ISubject subject)
        {
            FollowBall((subject as Ball).Position);
        }
    }
}
