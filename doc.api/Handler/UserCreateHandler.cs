using AutoMapper;
using doc.api.Constant;
using doc.api.Domain;
using doc.api.Dto;
using doc.api.Interface;
using doc.api.Message;

namespace doc.api.Handler
{
    public class UserCreateHandler : IGenericHandler<UserCreateRequest, BaseResponse<UserDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserCreateHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<UserDTO>> execute(UserCreateRequest request)
        {
            var user = new User()
            {
                Fullname = request.Fullname,
                Mail = request.Mail,
                Password = request.Password,
                Role = request.Role,
                Username = request.Username
            };
            var result = await _userRepository.Create(user);
            if (result > 0)
                return new BaseResponse<UserDTO>() { IsSuccess = true, Message = ResponseMessage.SUCCESS, Data = _mapper.Map<UserDTO>(user) };
            else
                return new BaseResponse<UserDTO>() { IsSuccess = false, Message = ResponseMessage.ERROR, Data = null };

        }
    }
}
