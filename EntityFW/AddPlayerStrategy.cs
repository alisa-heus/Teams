using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW
{
    internal class AddPlayerStrategy : IDialogStrategy
    {
        public void Handle(TeamsRegistrationDbContext context)
        {

            Console.WriteLine("Ok, let's add a player! What's their name?");
            string playerName = Console.ReadLine();

            if(playerName != null)
            {
                using (context)
                {
                    //Add player to a team
                }
            }
        }
    }
}
