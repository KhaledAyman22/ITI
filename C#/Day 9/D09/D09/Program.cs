namespace D09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> Lst = Enumerable.Range(0, 100).ToList();

            //List<int> oLst = Lst.FindAll(i => i % 8 == 0);

            //foreach( int i in oLst) { Console.Write($"{i} , "); }

            Ball ball = new Ball() { ID = 101, BallLocation = new Location() { X = 10, Y = 10, Z = 10 } };

            Player P11 = new Player() { Name = "P11", Team = "T01" };
            Player P12 = new Player() { Name = "P12", Team = "T01" };
            Player P21 = new Player() { Name = "P21", Team = "T02" };
            Player P22 = new Player() { Name = "P22", Team = "T02" };
            Player P23 = new Player() { Name = "P23", Team = "T02" };

            Referee R01 = new Referee() { Name = "R01" };


            ball.BallLocation = new() { X = 20, Y = 20, Z = 20 };


            ///Registration
            ///Add Pointer for Subsc. CallBack Method into Publisher invocaionList
            ball.BallLocationChanged += new Action<Location>(P11.Run);
            ball.BallLocationChanged += P12.Run;
            ball.BallLocationChanged += P21.Run;
            ball.BallLocationChanged += P22.Run;
            ball.BallLocationChanged += R01.Follow;
            ball.BallLocationChanged += D => Console.WriteLine($"Lambda Call back Method {D}");

            ball.BallLocation = new() { X = 40, Y = 40, Z = 40 };

            Console.WriteLine("Change in Players");
            ///UnRegister
            ball.BallLocationChanged -= P21.Run;
            ///Remove Pointer to P21 Call Back Method from event InvocationList
            ///Registration
            ball.BallLocationChanged += P23.Run;

            ball.BallLocation = new() { X = 60, Y = 60, Z = 60 };

        }
    }
}