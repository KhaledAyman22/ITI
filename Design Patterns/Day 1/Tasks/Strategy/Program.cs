global using static System.Console;
using StrategyPattern.Interfaces;
using StrategyPattern.Models;
using StrategyPattern.PlayerRoles;
using StrategyPattern.PlayGroundBuilders;
using StrategyPattern.TeamStrategies;

namespace StrategyPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameEngine engine = new GameEngine();

            Team team1 = new()
            {
                Players = new() { new GoalKeeper(),
                    new Defender(new FieldPlayer()), new Defender(new FieldPlayer()), new Defender(new FieldPlayer()), new Defender(new FieldPlayer()),
                    new Midfielder(new FieldPlayer()), new Midfielder(new FieldPlayer()), new Midfielder(new FieldPlayer()),
                    new Forward(new FieldPlayer()), new Forward(new FieldPlayer()), new Forward(new FieldPlayer())
                },
                Strategy = new AttackStrategy()
            };

            Team team2 = new()
            {
                Players = new() { new GoalKeeper(),
                    new Defender(new FieldPlayer()), new Defender(new FieldPlayer()), new Defender(new FieldPlayer()), new Defender(new FieldPlayer()),
                    new Midfielder(new FieldPlayer()), new Midfielder(new FieldPlayer()), new Midfielder(new FieldPlayer()),
                    new Forward(new FieldPlayer()), new Forward(new FieldPlayer()), new Forward(new FieldPlayer())
                },
                Strategy = new DefenceStrategy()
            };

            Referee[] referees = new Referee[] { new(), new(), new() };

            PlayGround playGround = new();
            PlayGroundDirector playGroundDirector = new();
            PlayGroundBuilder playGroundBuilder = new();
            playGroundDirector.builder = playGroundBuilder;
            playGroundDirector.BuildPlayGround();

            Ball ball = new(new(1,1));

            Game game = new(team1, team2, referees, ball, playGround);

            engine.Games.Add(game);


            ball.Position = new(5, 5);

            WriteLine(team1.Players[0].Operation());
            WriteLine(team1.Players[1].Operation());
            WriteLine(team1.Players[5].Operation());
            WriteLine(team1.Players[8].Operation());
        }
    }
}