﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW.Strategies
{
    internal class DefaultStrategy : Strategies.IDialogStrategy
    {
        public void Handle(TeamsRegistrationDbContext context)
        {
            Console.WriteLine("Invalid command.");
            Console.WriteLine("Available commands: \n /addplayers \n /addteams \n /resetteams \n /resetplayers \n /resetall \n /checkteams \n /play \n /showgames \n /addresults \n /getwins");
        }
    }
}
