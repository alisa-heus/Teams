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
        public void Handle(TeamsRegistrationDbContext context)
        {
            var playersToDelete = context.Players.ToList();
            var teamsToDelete = context.Teams.ToList();

            foreach (var player in playersToDelete)
            {
                context.Players.Remove(player);
            }

            foreach (var team in teamsToDelete)
            {
                context.Teams.Remove(team);
            }

            ProgressInfo.teamsCreated = false;
            context.SaveChanges();
            Console.WriteLine("You sucessfully deleted all the teams and players.");
            return;
        }
    }
}
