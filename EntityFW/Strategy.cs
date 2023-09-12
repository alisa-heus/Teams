using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            else
            {
                return new DefaultStrategy();
            }
        }
    }
}
