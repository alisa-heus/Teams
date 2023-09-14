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

            foreach (var player in playersToDelete)
            {
                context.Players.Remove(player);
            }
            context.SaveChanges();
            Console.WriteLine("You sucessfully deleted all the players.");
            return;
        }
    }
}
