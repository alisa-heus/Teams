using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW.Strategies
{
    internal class AddResultsStrategy : IDialogStrategy
    {
        public void Handle(TeamsRegistrationDbContext context)
        {
            if(!ProgressInfo.gamesCreated)
            {
                Console.WriteLine("You do not have any games yet.");
            }

            foreach (var game in context.Games)
            {
                Console.WriteLine($"For Game {game.GameID}: {game.ATeamName}:{game.BTeamName} enter score:");

                string score = Console.ReadLine();
                string[] results = score.Split(":"); 
                if (Convert.ToInt32(results[0])  > Convert.ToInt32(results[1]))
                {
                    game.ATeamScore = 1;
                } 
                else
                {
                    game.BTeamScore = 1;
                }
            }

            context.SaveChanges();
            Console.WriteLine("You successfully added the results");
            Console.WriteLine("Your results:");

            foreach (var game in context.Games)
            {
                Console.WriteLine($"For Game {game.GameID}: {game.ATeamName}:{game.BTeamName} - {game.ATeamScore}:{game.BTeamScore}");
            }
        }
    }
}
