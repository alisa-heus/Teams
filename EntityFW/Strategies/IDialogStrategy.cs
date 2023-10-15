using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW.Strategies
{
    public interface IDialogStrategy
    {
        string Handle(TeamsRegistrationDbContext context, string userMsgParams);
    }
}
