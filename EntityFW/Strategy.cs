using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFW.Strategies;

namespace EntityFW
{
    internal static class Strategy
    {
        public static IDialogStrategy ChooseStrategy(string message)
        {
            if(message.ToLower().Trim() == "/addplayers")
            {
                return new AddPlayerStrategy(); 
            }
            else if(message.ToLower().Trim() == "/addteams")
            {
                return new AddTeamStrategy();
            }
            else if(message.ToLower().Trim() == "/resetteams")
            {
                return new ResetTeamsStrategy();
            }
            else if(message.ToLower().Trim() == "/resetplayers")
            {
                return new ResetPlayersStrategy();
            }
            else if (message.ToLower().Trim() == "/checkteams")
            {
                return new CheckTeamsStrategy();
            }
            else
            {
                return new DefaultStrategy();
            }
        }
    }
}
