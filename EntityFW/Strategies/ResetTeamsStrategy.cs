using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW.Strategies
{
    internal class ResetTeamsStrategy : IDialogStrategy
    {
        public string Handle(TeamsRegistrationDbContext context, string userMsgParams)
        {
            var playersToDelete = context.Players.ToList();
            var teamsToDelete = context.Teams.ToList();
            var gamesToDelete = context.Games.ToList();

            foreach (var player in playersToDelete)
            {
                context.Players.Remove(player);
            }

            foreach (var team in teamsToDelete)
            {
                context.Teams.Remove(team);
            }

            if(ProgressInfo.gamesCreated)
            {
                foreach (var game in gamesToDelete)
                {
                    context.Games.Remove(game);
                }

                ProgressInfo.gamesCreated = false;
            }

            ProgressInfo.teamsCreated = false;
            context.SaveChanges();
            // Console.WriteLine("You sucessfully deleted all the teams and players.");
            return "You sucessfully deleted all the teams and players.";
        }
    }
}
