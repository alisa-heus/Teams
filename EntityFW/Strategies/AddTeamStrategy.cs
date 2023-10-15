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
        public string Handle(TeamsRegistrationDbContext context, string userMsgParams)
        {
            if (ProgressInfo.teamsCreated == false)
            {
                if (string.IsNullOrEmpty(userMsgParams))
                {
                    // Console.WriteLine("Cool!, how many players are you today?");
                    return "Cool!, how many players are you today?";
                }
                int playersAmount = 0;
                if (int.TryParse(userMsgParams, out playersAmount))
                {
                    ProgressInfo.totalPlayers = Math.Abs(playersAmount);

                    if (playersAmount % 3 == 0 && playersAmount > 3)
                    {
                        // Console.WriteLine("You are playing triples today!");
                        ProgressInfo.teamsSize = 3;
                        CreateTeams(context, playersAmount / 3);
                        return "You are playing triples today!";
                    }
                    else if (playersAmount % 4 == 0)
                    {
                        // Console.WriteLine("You are playing doubles today!");
                        ProgressInfo.teamsSize = 2;
                        CreateTeams(context, playersAmount / 2);
                        return "You are playing doubles today!";
                    }
                    else
                    {
                        // Console.WriteLine("You are playing tete-a-tete today!");
                        ProgressInfo.teamsSize = 1;
                        CreateTeams(context, playersAmount);
                        return "You are playing tete-a-tete today!";
                    }
                }
                else
                {
                    return "Please enter the number of players.";
                }
            }
            else
            {
                // Console.WriteLine("You already created teams.\nEnter /resetteams to delete teams and players or /addplayer to add a player.");
                return "You already created teams.\nEnter /resetteams to delete teams and players or /addplayer to add a player.";
            }
        }

        private void CreateTeams(TeamsRegistrationDbContext context, int numberOfTeams)
        {
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
