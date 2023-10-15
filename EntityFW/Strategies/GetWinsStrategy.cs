using EntityFW.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW.Strategies
{
    internal class GetWinsStrategy : IDialogStrategy
    {
        public void Handle(TeamsRegistrationDbContext context)
        {
            var teamScoresDictionary = new Dictionary<string, int>();

            foreach(Game game in context.Games)
            {
                if (teamScoresDictionary.ContainsKey(game.ATeamName))
                {
                    int team1Score = teamScoresDictionary[game.ATeamName];
                    teamScoresDictionary[game.ATeamName] = team1Score + game.ATeamScore;
                } else
                {
                    teamScoresDictionary.Add(game.ATeamName, game.ATeamScore);
                }

                if (teamScoresDictionary.ContainsKey(game.BTeamName))
                {
                    int team2Score = teamScoresDictionary[game.BTeamName];
                    teamScoresDictionary[game.BTeamName] = team2Score + game.BTeamScore;
                }
                else
                {
                    teamScoresDictionary.Add(game.BTeamName, game.BTeamScore);
                }
            }
            Console.WriteLine("Teams Scores:");
            var sortedDictionary = teamScoresDictionary.OrderByDescending(pair => pair.Value);

            foreach (var item in sortedDictionary)
            {
                Console.WriteLine($"Team {item.Key} score: {item.Value}");
            }

            
            var winningTeamName = sortedDictionary.First().Key;

            foreach (Team team in context.Teams)
            {
                if(team.Name ==  winningTeamName)
                {
                    Console.WriteLine($"The winner team is {team.Name}! Congratulations: ");
                    foreach (Player p in team.Players)
                    {
                        Console.Write(p.NickName);
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
