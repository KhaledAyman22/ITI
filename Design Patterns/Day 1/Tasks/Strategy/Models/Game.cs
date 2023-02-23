using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Models
{
    internal class Game
    {
        public Team Team1 { get; init; }

        public Team Team2 { get; init; }

        public Ball Ball { get; init; }

        public Referee[] Referees { get; init; }

        public PlayGround PlayGround { get; init; }


        public Game(Team team1, Team team2, Referee[] referees, Ball ball, PlayGround playGround)
        {
            Team1 = team1;
            Team2 = team2;
            Referees = referees;
            Ball = ball;
            PlayGround = playGround;
            SubscribeTeamPlayers(Team1);
            SubscribeTeamPlayers(Team2);
            SubscribeReferees();
        }


        private void SubscribeTeamPlayers(Team t)
        {
            foreach (var player in t.Players)
            {
                Ball.Attach(player);
                recurse(player);
            }

            void recurse(Player player)
            {
                if (player is PlayerRole playerRole)
                {
                    Ball.Attach(playerRole.Player);
                    recurse(playerRole.Player);
                }
            }
        }

        private void SubscribeReferees()
        {
            foreach (var referee in Referees)
            {
                Ball.Attach(referee);
            }
        }
    }
}
