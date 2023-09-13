using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW.Strategies
{
    internal interface IDialogStrategy
    {
        void Handle(TeamsRegistrationDbContext context);
    }
}
