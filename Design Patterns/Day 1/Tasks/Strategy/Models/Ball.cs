using StrategyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Models
{
    internal class Ball : ISubject
    {
        private Point position;
        public Point Position
        {
            get => position; set
            {
                position = value;
                Notify();
            }
        }
        
        private List<IObserver> _observers = new();

        public Ball(Point _position)
        {
            position.X = _position.X;
            position.Y = _position.Y;
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
}
