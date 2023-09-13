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
            if(message.ToLower().Trim() == "/addplayer")
            {
                return new AddPlayerStrategy(); 
            }
            else if(message.ToLower().Trim() == "/addteam")
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
            else
            {
                return new DefaultStrategy();
            }
        }
    }
}
