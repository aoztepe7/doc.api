using doc.api.Constant;

namespace doc.api.Message
{
    public class UserCreateRequest
    {
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public Enums.Role Role { get; set; }
    }
}
