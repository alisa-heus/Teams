using EntityFW.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW.Strategies
{
    internal class AddTeamStrategy : IDialogStrategy
    {
        public void Handle(TeamsRegistrationDbContext context)
        {
            if (ProgressInfo.teamsCreated == false)
            {
                Console.WriteLine("Cool!, how many players are you today?");
                int playersAmount = Convert.ToInt32(Console.ReadLine());


                if (playersAmount % 3 == 0)
                {
                    Console.WriteLine("You are playing triples today!");
                    ProgressInfo.teamsSize = 3;
                    CreateTeams(context, playersAmount / 3);
                }
                else if (playersAmount % 2 == 0)
                {
                    Console.WriteLine("You are playing doubles today!");
                    ProgressInfo.teamsSize = 2;
                    CreateTeams(context, playersAmount / 2);
                }
                else
                {
                    Console.WriteLine("You are playing tete-a-tete today!");
                    ProgressInfo.teamsSize = 1;
                    CreateTeams(context, playersAmount);
                }
            }
            else
            {
                Console.WriteLine("You already created teams.\nEnter /resetteams to delete teams and players or /addplayer to add a player.");
                return;
            }
        }

        private void CreateTeams(TeamsRegistrationDbContext context, int numberOfTeams)
        {
            using(context)
            {
                context.Teams.ExecuteDelete();

                for (int i = 1; i <= numberOfTeams; i++)
                {
                    var team = new Team
                    {
                        Name = $"Team{i}",
                    };
                    context.Teams.Add(team);
                }

                ProgressInfo.teamsCreated = true;
                context.SaveChanges();
            }   
        }
    }
}
