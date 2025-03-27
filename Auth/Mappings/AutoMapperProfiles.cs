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
            CreateMap<ApplicationUser, LoginResponseDto>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();

            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Post, AddPostRequestDto>().ReverseMap();
            CreateMap<Post, UpdatePostRequestDto>().ReverseMap();

            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, AddCommentRequestDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentRequestDto>().ReverseMap();
        }
    }
}
