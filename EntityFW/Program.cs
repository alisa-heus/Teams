using EntityFW;
using EntityFW.Models;
using EntityFW.Strategies;
using Microsoft.EntityFrameworkCore;

//Petanque is a French game that can be played with 3, 2 or 1 player in the team. 
//I plan to create a program that will randomly divide players into teams for their training.
//The program will ask the user for a number of players that came to train today.
//Depending on the number of players, it will create teams of doubles, triples or single-player teams.
//Then,it will ask the user to enter nicknames of the players.
//When the list of players is full, it will randomly assign players to different teams. 
using (var context = new TeamsRegistrationDbContext())
{
    while (true)
    {
        Console.WriteLine("Enter a command");
        string command = Console.ReadLine();
        if (command != null)
        {
            IDialogStrategy strategy = Strategy.ChooseStrategy(command);
            strategy.Handle(context);
        }
    }
}
    