using System;

namespace DoFactory.HeadFirst.Decorator.Starbuzz
{
    class StarbuzzCoffee
    {
        public static void ProcessBeverage ( Beverage beverage)
        {
            Console.WriteLine(beverage.Description
               + " $" + beverage.Cost);
        }

        static void Main(string[] args)
        {
            //Beverage beverage = new Espresso();

            //Console.WriteLine(beverage.Description
            //    + " $" + beverage.Cost);

            Beverage beverage2 = new DarkRoast();
            beverage2 = new Mocha(beverage2);
            beverage2 = new Mocha(beverage2);
            beverage2 = new Whip(beverage2);
            beverage2 = new CaramelDercorator(beverage2);
            //Console.WriteLine(beverage2.Description
            //    + " $" + beverage2.Cost);

            ProcessBeverage(beverage2);

            //Beverage beverage3 = new HouseBlend();
            //beverage3 = new Soy(beverage3);
            //beverage3 = new Mocha(beverage3);
            //beverage3 = new Whip(beverage3);
            //Console.WriteLine(beverage3.Description
            //    + " $" + beverage3.Cost);

            // Wait for user
            Console.ReadKey();
        }
    }

    #region Beverage
    ///IComponent 
    public class Beverage
    {
        public virtual string Description { get; protected set; }
        public virtual double Cost { get; protected set; }
    }

    ///ConcreteComponentA
    public class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            Description = "Dark Roast Coffee";
            Cost = 0.99;
        }
    }

    ///ConcreteComponentB
    public class Decaf : Beverage
    {
        public Decaf()
        {
            Description = "Decaf Coffee";
            Cost = 1.05;
        }
    }
    
    ///ConcreteComponentC
    public class Espresso : Beverage
    {
        public Espresso()
        {
            Description = "Espresso";
            Cost = 1.99;
        }
    }
  
    ///ConcreteComponentD
    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            Description = "House Blend Coffee";
            Cost = 0.89;
        }
    }

    #endregion

    #region CondimentDecorator

    ///Concrete Decorator 01
    public class Whip : Beverage //Is A
    {
        private Beverage _beverage; //Has A

        public Whip(Beverage beverage)
        {
            this._beverage = beverage;
        }

        public override string Description
        {
            ///Attach it's Own State/Behavior After/Before Delegation to Decorated Object (Component)
            get { return _beverage.Description + ", Whip"; }
        }

        public override double Cost
        {
            get { return .10 + _beverage.Cost; }
        }
    }

    /// <summary>
    /// Concrete Decorator 02
    /// </summary>
    public class Milk : Beverage
    {
        private Beverage _beverage;

        public Milk(Beverage beverage)
        {
            this._beverage = beverage;
        }

        public override string Description
        {
            get { return _beverage.Description + ", Milk"; }
        }

        public override double Cost
        {
            get { return .10 + _beverage.Cost; }
        }
    }

    /// <summary>
    /// Concrete Decorator 3
    /// </summary>
    public class Mocha : Beverage
    {
        private Beverage _beverage;

        public Mocha(Beverage beverage)
        {
            this._beverage = beverage;
        }

        public override string Description
        {
            get { return _beverage.Description + ", Mocha"; }
        }

        public override double Cost
        {
            get { return .20 + _beverage.Cost; }
        }
    }

    public class Soy : Beverage
    {
        private Beverage _beverage;

        public Soy(Beverage beverage)
        {
            this._beverage = beverage;
        }

        public override string Description
        {
            get { return _beverage.Description + ", Soy"; }
        }

        public override double Cost
        {
            get { return .15 + _beverage.Cost; }
        }
    }

    public class CaramelDercorator : Beverage
    {
        Beverage beverage;

        public CaramelDercorator(Beverage _beverage)
            => beverage = _beverage;

        public override double Cost { get => 0.25+beverage.Cost;  }

        ///Delegation
        public override string Description { get => beverage.Description + " With Caramel";  }
    }
   

    #endregion

  


}