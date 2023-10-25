using AutoMapper;
using hackathon_api.Models;
using hackathon_api.Models.DTOs;

namespace hackathon_api.Profiles;
public class AuthProfile : Profile
{
    public AuthProfile()
    {
        CreateMap<LoginDTO, User>().ReverseMap();
        CreateMap<Profile, LoginDTO>();
    }
}
