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
        public void Handle(TeamsRegistrationDbContext context)
        {
            int playersLeftToAdd = ProgressInfo.totalPlayers;

            if (ProgressInfo.teamsCreated == false)
            {
                Console.WriteLine("Please, add teams first.");
                return;
            }

            Console.WriteLine("Let's start adding players!");

            while (playersLeftToAdd > 0)
            {
                Console.WriteLine("Enter player's nick name!");
                string playerName = Console.ReadLine();

                while(true)
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
                        Console.WriteLine($"You sucessfully added {playerName} to a {randomTeam.Name}");
                        break;
                    }
                }    
            }

            Console.WriteLine("Teams are full!");
            Console.WriteLine("To review teams enter /checkteams");
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
