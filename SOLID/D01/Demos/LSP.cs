Main()
{
    RubberDuck d1,
    RealDuck d2;
    Duck[] ducks;
    foreach(x in ducks)
    {
        x.Quack();//Error unexpected
    }
    d1.Quack(); // Error unexpected behavior
    d2.Quack();
}
// When Rubber duck inherit Duck this violates LSP 
// As "RubberDuck" class not totally substitutable by the parent class "Duck"
class Duck{ 
    public void Quack()
    {
        Console.WriteLine("Quaaaaaack");
    }
}
interface IQuack /// Recommending using interface 
{
    void Quack();
}
class RubberDuck:IQuack
{
    bool HasBattery {set; get;}

    void Quack()
    {
        if(HasBattery)
            Console.WriteLine("Quaaaaaack");
        // what if not has battery /// un expected or unhandled behaviour
    }
}

class RealDuck:IQuack
{    
    void Quack()
    {
        Console.WriteLine("Quaaaaaack");
    }
} 