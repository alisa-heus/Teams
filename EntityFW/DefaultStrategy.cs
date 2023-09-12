using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW
{
    internal class DefaultStrategy : IDialogStrategy
    {
        public void Handle(TeamsRegistrationDbContext context)
        {
            Console.WriteLine("Invalid command.");
            Console.WriteLine("Available commands: \n /addplayer \n /addteam");
        }
    }
}
