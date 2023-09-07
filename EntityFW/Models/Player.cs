namespace EntityFW.Models
{
    public class Player : BaseModel
    {
        public string NickName { get; set; }
        public long TeamId { get; set; }
        public Team Team { get; set; }
    }
}
