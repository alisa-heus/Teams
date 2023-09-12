namespace EntityFW.Models
{
    public class Team : BaseModel
    {
        public int TeamID { get; set; }
        public string? Name { get; set; }
        public int TeamSize { get; set; }
        public virtual List<Player>? Players { get; set; }
    }
}
