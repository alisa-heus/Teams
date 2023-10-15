using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFW.Strategies;

namespace EntityFW
{
    public static class Strategy
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
            else if(message.ToLower().Trim() == "/checkteams")
            {
                return new CheckTeamsStrategy();
            }
            else if(message.ToLower().Trim() == "/play")
            {
                return new GameOrganizerStrategy();
            }
            else if (message.ToLower().Trim() == "/addresults")
            {
                return new AddResultsStrategy();
            }
            else if (message.ToLower().Trim() == "/getwins")
            {
                return new GetWinsStrategy();
            }
            else if (message.ToLower().Trim() == "/resetall")
            {
                return new ResetAllStrategy();
            }
            else
            {
                return new DefaultStrategy();
            }
        }
    }
}
