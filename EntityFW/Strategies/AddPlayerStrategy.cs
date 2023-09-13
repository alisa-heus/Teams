using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW.Strategies
{
    internal class AddPlayerStrategy : IDialogStrategy
    {
        public void Handle(TeamsRegistrationDbContext context)
        {
            if (ProgressInfo.teamsCreated == false)
            {
                Console.WriteLine("Please, add teams first.");
                return;
            }
            else
            {
                Console.WriteLine("Ok, let's add a player! What's their name?");
                string playerName = Console.ReadLine();

                if (playerName != null)
                {
                    using (context)
                    {
                        //Add player to a team
                    }
                }
            }

        }
    }
}
