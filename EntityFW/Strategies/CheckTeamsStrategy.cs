using EntityFW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW.Strategies
{
    internal class CheckTeamsStrategy : IDialogStrategy
    {
        public void Handle(TeamsRegistrationDbContext context)
        {
            if(context.Teams == null)
            {
                Console.WriteLine("You don't have any teams. Enter /addteams to add teams.");
            }
            if(context.Players == null) 
            {
                Console.WriteLine("You don't have any players in the list. Enter /addplayers to add players.");
            }

            Console.WriteLine($"You have {context.Teams.Count()} teams today.");
            Console.WriteLine(" ");

            foreach(Team team in context.Teams)
            {
                Console.WriteLine($"==={team.Name}===");
                foreach (Player p in team.Players)
                {
                    Console.WriteLine(p.NickName);
                }
                Console.WriteLine(" ");
            }  
        }
    }
}
