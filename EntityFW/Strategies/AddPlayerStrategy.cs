using EntityFW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW.Strategies
{
    internal class AddPlayerStrategy : IDialogStrategy
    {
        public string Handle(TeamsRegistrationDbContext context, string userMsgParams)
        {
            int playersLeftToAdd = ProgressInfo.totalPlayers;

            if (ProgressInfo.teamsCreated == false)
            {
                // Console.WriteLine("Please, add teams first.");
                return "Please, add teams first.";
            }

            //Console.WriteLine("Let's start adding players!");
            if(string.IsNullOrEmpty(userMsgParams))
            {
                return "Enter player's nick name!";
            } else
            {
                string playerName = userMsgParams;
                Team randomTeam = FindRandomTeam(context);
                if (randomTeam.Players.Count < ProgressInfo.teamsSize)
                {
                    var player = new Player()
                    {
                        NickName = playerName,
                        TeamID = randomTeam.TeamID
                    };
                    context.Players.Add(player);
                    playersLeftToAdd--;
                    context.SaveChanges();
                    //Console.WriteLine($"You sucessfully added {playerName} to a {randomTeam.Name}");
                    return $"You sucessfully added {playerName} to a {randomTeam.Name}";
                } else
                {
                    return "No more players can be added.";
                }
            }

            /*
            while (playersLeftToAdd > 0)
            {
                //Console.WriteLine("Enter player's nick name!");
                // string playerName = Console.ReadLine();
                string playerName = userMsgParams;
                while (true)
                {
                    Team randomTeam = FindRandomTeam(context);

                    if (randomTeam.Players.Count < ProgressInfo.teamsSize)
                    {
                        var player = new Player()
                        {
                            NickName = playerName,
                            TeamID = randomTeam.TeamID
                        };
                        context.Players.Add(player);
                        playersLeftToAdd--;
                        context.SaveChanges();
                        //Console.WriteLine($"You sucessfully added {playerName} to a {randomTeam.Name}");
                        break;
                    }
                }    
            }
            return "Teams are full!" + "To review teams enter /checkteams";
            // Console.WriteLine("Teams are full!");
            // Console.WriteLine("To review teams enter /checkteams");
            */
        }

        private Team FindRandomTeam(TeamsRegistrationDbContext context)
        {
            Random random = new Random();
            int teamsCount = context.Teams.Count();
            int randomIndex = random.Next(teamsCount);

            var randomTeam = context.Teams.OrderBy(x => x.TeamID).Skip(randomIndex).FirstOrDefault();

            return randomTeam;
        }
    }
}
