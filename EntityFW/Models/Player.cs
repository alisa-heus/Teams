namespace EntityFW.Models
{
    public class Player : BaseModel 
    {
        public int PlayerID { get; set; }
        public string? NickName { get; set; }
        public int TeamID { get; set; }
        public virtual Team? Team { get; set; }
    }
}
