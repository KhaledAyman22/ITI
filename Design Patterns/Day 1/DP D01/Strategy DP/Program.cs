using Strategy_DP.StategyDP;

namespace Strategy_DP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MallardDuck MD = new();
            MD.Swim();
            MD.Fly();
            MD.Quack();
            MD.Display();


            RubberDuck RD = new();
            RD.Swim();
            RD.Fly();
            RD.Quack();
            RD.Display();

            Console.WriteLine("Hunting Mode");
            ///Open for Extension : Add new Behavior (Fly Rocket Speed)
            ///Closed for Modification : no updates required in Old Code
            MD.FlyBehavior = new FlyRocketSpeed();
            
            MD.Fly();
        }
    }
}