using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW.Strategies
{
    internal class ResetPlayersStrategy : IDialogStrategy
    {
        public void Handle(TeamsRegistrationDbContext context)
        {
            var playersToDelete = context.Players.ToList();
            var gamesToDelete = context.Games.ToList();

            foreach (var player in playersToDelete)
            {
                context.Players.Remove(player);
            }

            if (ProgressInfo.gamesCreated)
            {
                foreach (var game in gamesToDelete)
                {
                    context.Games.Remove(game);
                }

                ProgressInfo.gamesCreated = false;
            }
            context.SaveChanges();
            Console.WriteLine("You sucessfully deleted all the players.");
            return;
        }
    }
}
