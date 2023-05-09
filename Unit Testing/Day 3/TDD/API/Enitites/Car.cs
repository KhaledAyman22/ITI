using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Entities
{
    public enum CarType
    {
        Audi,
        BMW
    }
    public class Car
    {
        public int Id { get; }
        public CarType Type { get; set; }

        public double Velocity { get; set; }

        public Car(int id,CarType carType,double initialVelocity)
        {
            Id = id;
            Type = carType;
            Velocity = initialVelocity;
        }
        public Car()
        {

        }
        public Car(int id)
        {
            Id = id;
        }

        public Owner Owner { get; set;}

        
    }
}