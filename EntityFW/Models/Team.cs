namespace EntityFW.Models
{
    public class Team : BaseModel
    {
        public string Name { get; set; }
        public double TeamScore { get; set; }
        public List<Player> Players { get; }
    }
}
