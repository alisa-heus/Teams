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
                context.Teams.ExecuteDelete();
                ProgressInfo.teamsSize = 0;
                context.Players.ExecuteDelete();
                context.SaveChanges();
                Console.WriteLine("You sucessfully deleted teams and players.");
                return;
        }
    }
}
