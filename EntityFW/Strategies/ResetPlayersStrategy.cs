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
            context.Players.ExecuteDelete();
            context.SaveChanges();
            Console.WriteLine("You sucessfully deleted all the players.");
            return;
        }
    }
}
