namespace SmartAPI.Data.Entity
{
    public class UserCredential : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public long UserId { get; set; }
    }
}
