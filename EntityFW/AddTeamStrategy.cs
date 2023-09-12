using EntityFW.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW
{
    internal class AddTeamStrategy : IDialogStrategy
    {
        public void Handle(TeamsRegistrationDbContext context)
        {   
            Console.WriteLine("Cool!, how many players are today?");
            int playersAmount = Convert.ToInt32(Console.ReadLine());


            if (playersAmount % 3 == 0)
            {
                Console.WriteLine("You are playing tripplets today!");
                CreateTeams(context, playersAmount / 3);  
            }
            else if (playersAmount % 2 == 0)
            {
                Console.WriteLine("You are playing duplets today!");
                CreateTeams(context, playersAmount / 2);
            }
            else
            {
                Console.WriteLine("You are playing tete-a-tete today!");
                CreateTeams(context, playersAmount);
            }   
        }

        private void CreateTeams(TeamsRegistrationDbContext context, int numberOfTeams)
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
        }
    }
}
