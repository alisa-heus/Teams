using EntityFW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW.Strategies
{
    internal class GameOrganizerStrategy : IDialogStrategy
    {
        public string Handle(TeamsRegistrationDbContext context, string userMsgParams)
        {
            if(ProgressInfo.teamsCreated != false)
            {
                List<Game> games = new List<Game>();
                return ArrangeGamesForTeams(context, games);
                 
            }
            else
            {
                Console.WriteLine("Create teams first");
                return "Create teams first";
            }
        }

        private string ArrangeGamesForTeams(TeamsRegistrationDbContext context, List<Game> games)
        {
            if(!ProgressInfo.gamesCreated)
            {
                List<Team> teams = context.Teams.ToList();
                for (int i = 0; i < teams.Count - 1; i++)
                {
                    for (int j = i + 1; j < teams.Count; j++)
                    {
                        var game = new Game();
                        game.ATeamID = teams[i].TeamID;
                        game.ATeamName = teams[i].Name;

                        game.BTeamID = teams[j].TeamID;
                        game.BTeamName = teams[j].Name;
                        context.Games.Add(game);
                    }
                }

                ProgressInfo.gamesCreated = true;
                context.SaveChanges();
                // Console.WriteLine("Games:");

                string result = "";
                foreach (var game in context.Games)
                {
                    // Console.WriteLine($"Game {game.GameID}: {game.ATeamName} is playng against {game.BTeamName}");
                    result += $"Game {game.GameID}: {game.ATeamName} is playng against {game.BTeamName}";
                }
                return result;
            } 
            else
            {
                //Console.WriteLine("Games already exist.");
                // Console.WriteLine("Games:");
                string result = "";
                foreach (var game in context.Games)
                {
                    // Console.WriteLine($"Game {game.GameID}: {game.ATeamName} is playng against {game.BTeamName}");
                    result += $"Game {game.GameID}: {game.ATeamName} is playng against {game.BTeamName}";
                }
                return result;
            }
        }
    }
}
