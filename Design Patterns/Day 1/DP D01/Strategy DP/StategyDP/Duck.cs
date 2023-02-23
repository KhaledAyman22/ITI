using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_DP.StategyDP
{
    public abstract class Duck
    {

        /// <summary>
        /// Provide Fly Behavior through Composition not through Inheritance
        /// </summary>
        public IFlyBehavior FlyBehavior { get; set; }

        /// <summary>
        /// Develop Against Abstraction (Base class for Behavior) 
        /// not Against Concrete Implementaiton ( any Specific Quack Behavior)
        /// </summary>
        public IQuackBehavior QuackBehavior { get; set; }


        public Duck(IFlyBehavior fly , IQuackBehavior quack)
        {
            FlyBehavior = fly;
            QuackBehavior = quack;
        }


        public void Fly()
        {
            ///Delegate Fly Behavior to Strategy Object
            FlyBehavior.PerformFly();
        }


        public void Quack() => QuackBehavior.PerformQuack();


        public abstract void Display();

        public void Swim() => Console.WriteLine("Duck is Swimming");
    }
}
