using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp
{
    public enum CarType
    {
        BMW,
        Audi,
        Mercedes,
        Toyota,
        Honda
    }

    public enum DrivingMode
    {
        Stopped,
        Forward,
        Reverse
    }
    public class Car
    {
        public CarType Type { get; set; }
        public double Velocity { get; set; }
        public DrivingMode DrivingMode { get; set; } = DrivingMode.Stopped;

        public Car()
        {

        }

        public Car(CarType type,double initialVelocity,DrivingMode drivingMode)
        {
            Type = type;
            Velocity = initialVelocity;
            DrivingMode = drivingMode;
        }

        public double TimeToCoverProvidedDistance(double distance)
        {
            return distance / Velocity;
        }

        public void Accelerate()
        {
            switch (Type)
            {
                case CarType.Toyota:
                    Velocity = IncreaseVelocity(10);
                    break;
                case CarType.BMW:
                    Velocity = IncreaseVelocity(15);
                    break;
                case CarType.Mercedes:
                    Velocity = IncreaseVelocity(20);
                    break;
                case CarType.Audi:
                    Velocity = IncreaseVelocity(25);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private double IncreaseVelocity(double Increment)
        {
            return Velocity + Increment;
        }

        public void Brake()
        {
            switch (Type)
            {
                case CarType.Toyota:
                    Velocity -= 10;
                    break;
                case CarType.BMW:
                    Velocity -= 15;
                    break;
                case CarType.Mercedes:
                    Velocity -= 20;
                    break;
                case CarType.Audi:
                    Velocity -= 25;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void Stop()
        {
            Velocity = 0;
        }

        public bool IsStopped()
        {
            return this.Velocity == 0;
        }

        public string GetDirection()
        {
            string direction;
            switch (DrivingMode)
            {
                case DrivingMode.Forward:
                    direction = "Forward";
                    break;
                case DrivingMode.Reverse:
                    direction = "Reverse";
                    break;
                case DrivingMode.Stopped:
                    direction = "Stopped";
                    break;
                default:
                    direction = "";
                    break;
            }
            return direction;
        }

        public Car GetMyCar()
        {
            // logic
            return this;
        }

        public override bool Equals(object obj)
        {
            Car car = obj as Car;
            return car.Type == this.Type;
        }
    }
}
