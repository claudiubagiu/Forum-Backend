using Auth.Models.Domain;
using Auth.Models.DTOs;
using Auth.Repositories.Interface;
using Auth.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Auth.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITokenRepository tokenRepository;
        private readonly IMapper mapper;

        public AuthService(UserManager<ApplicationUser> userManager, ITokenRepository tokenRepository, IMapper mapper)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
            this.mapper = mapper;
        }

        public async Task<LoginResponseDto?> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Email);
            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        var jwtToken = tokenRepository.CreateToken(user, roles.ToList());
                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken,
                            Email = loginRequestDto.Email,
                            Roles = roles.ToList()
                        };
                        return response;
                    }
                }
            }
            return null;
        }

        public async Task<LoginResponseDto?> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var user = mapper.Map<ApplicationUser>(registerRequestDto);

            var result = await userManager.CreateAsync(user, registerRequestDto.Password);

            if (result.Succeeded)
            { 
                result = await userManager.AddToRolesAsync(user, new List<String>{"User"});

                if (result.Succeeded)
                {
                    var response = mapper.Map<LoginResponseDto>(user);
                    return response;
                }

            }
            return null;
        }
    }
}
