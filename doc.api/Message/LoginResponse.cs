using doc.api.Domain;
using doc.api.Dto;

namespace doc.api.Message
{
    public class LoginResponse : CommonResponse
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}
