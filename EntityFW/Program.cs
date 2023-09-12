using EntityFW;
using EntityFW.Models;
using Microsoft.EntityFrameworkCore;

//Petanque is a French game that can be played with 3, 2 or 1 player in the team. 
//I plan to create a program that will randomly divide players into teams for their training.
//The program will ask the user for a number of players that came to train today.
//Depending on the number of players, it will create teams of duplets, tripplets or single-player teams.
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
    
/*using (var context = new TeamsRegistrationDbContext())
{
    bool teamsCreated = false;
    Console.WriteLine("How many teams do you want to create?");
    int numberOfTeams = Convert.ToInt32(Console.ReadLine());
    CreateTeams(numberOfTeams);

    Console.WriteLine("Enter a player's nick name.");
    string nickName = Console.ReadLine();
    CreatePlayer(nickName);

    void CreateTeams(int numberOfTeams)
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
        teamsCreated = true;
        context.SaveChanges();
        Console.WriteLine($"{numberOfTeams} teams were created");
    }
    void CreatePlayer(string nickName)
    {
        var player = new Player()
        {
            NickName = nickName,
        };
        context.Players.Add(player);
    }
    
    var teams = context.Teams.ToList();
    var team1 = teams[0];

    for (int i = 1; i <= 10; i++)
    {
        var user = new Player
        {
            NickName = $"Player{i}",
            TeamID = team1.TeamID
        };
        context.Players.Add(user);  
    }
    context.SaveChanges();   
}*/