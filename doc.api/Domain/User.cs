using doc.api.Constant;

namespace doc.api.Domain
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Mail { get; set; }
        public Enums.Role Role { get; set; }
    }
}
