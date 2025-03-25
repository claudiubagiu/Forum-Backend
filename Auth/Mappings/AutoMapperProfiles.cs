using Auth.Models.Domain;
using Auth.Models.DTOs;
using AutoMapper;
using Microsoft.Extensions.Hosting;

namespace Auth.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterRequestDto, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUserDto, RegisterRequestDto>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            CreateMap<ApplicationUser, LoginResponseDto>().ReverseMap();
        }

    }
}
