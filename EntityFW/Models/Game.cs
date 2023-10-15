using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW.Models
{
    public class Game : BaseModel
    {
        public int GameID { get; set; }
        public int ATeamID { get; set; }
        public int BTeamID { get; set; }

        public string ATeamName { get; set; }
        public string BTeamName { get; set; }
        public int ATeamScore { get; set; }
        public int BTeamScore { get; set; }
    }
}
