using AutoMapper;
using doc.api.Domain;
using doc.api.Dto;

namespace doc.api.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
