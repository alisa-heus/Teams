using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW.Strategies
{
    internal class ResetAllStrategy : IDialogStrategy
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

            if (ProgressInfo.gamesCreated)
            {
                foreach (var game in gamesToDelete)
                {
                    context.Games.Remove(game);
                }
            }

            ProgressInfo.teamsCreated = false;
            ProgressInfo.teamsSize = 0;
            ProgressInfo.totalPlayers = 0;
            ProgressInfo.gamesCreated = false;

            context.SaveChanges();
            //Console.WriteLine("Reset was successful.");
            return "Reset was successful.";
        }
    }
}
