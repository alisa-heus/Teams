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
        public string Handle(TeamsRegistrationDbContext context, string userMsgParams)
        {
            if(context.Teams == null)
            {
                // Console.WriteLine("You don't have any teams. Enter /addteams to add teams.");
                return "You don't have any teams. Enter /addteams to add teams.";
            }
            if(context.Players == null) 
            {
                // Console.WriteLine("You don't have any players in the list. Enter /addplayers to add players.");
                return "You don't have any players in the list. Enter /addplayers to add players.";
            }

            string result = $"You have {context.Teams.Count()} teams today.";
            //nsole.WriteLine($"You have {context.Teams.Count()} teams today.");
            //nsole.WriteLine(" ");

            foreach(Team team in context.Teams)
            {
                //Console.WriteLine($"==={team.Name}===");
                result += $"==={team.Name}===\n";
                foreach (Player p in team.Players)
                {
                    //Console.WriteLine(p.NickName);
                    result += p.NickName;
                    result += '\n';
                }
                //Console.WriteLine(" ");
            }  
            return result;
        }
    }
}
