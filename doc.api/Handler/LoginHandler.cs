using AutoMapper;
using doc.api.Constant;
using doc.api.Dto;
using doc.api.Interface;
using doc.api.Message;
using doc.api.Service;

namespace doc.api.Handler
{
    public class LoginHandler : IGenericHandler<LoginRequest, LoginResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;
        private readonly IMapper _mapper;

        public LoginHandler(IUserRepository userRepository, TokenService tokenService, IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<LoginResponse> execute(LoginRequest request)
        {
            var user = await _userRepository.GetByMailAndPassword(request.Mail, request.Password);
            if (user != null)
            {
                var token = _tokenService.GenerateToken(user);
                return new LoginResponse() { IsSuccess = true, Message = ResponseMessage.SUCCESS, Token = token, User = _mapper.Map<UserDTO>(user) };
            }
            else
                return new LoginResponse() { IsSuccess = false, Message = ResponseMessage.INVALID_CREDENTIALS, Token = null, User = null };
        }
    }
}
