using Auth.Models.Domain;
using Auth.Models.DTOs;
using System.Security.Claims;

namespace Auth.Services.Interface
{
    public interface IPostService
    {
        Task<PostDto?> CreateAsync(AddPostRequestDto addPostRequestDto, DateTime dateTime, string userId);
        Task<PostDto?> GetByIdAsync(Guid id);
        Task<List<PostDto>?> GetAllAsync();
        Task<PostDto?> UpdateAsync(Guid id, UpdatePostRequestDto updatePostRequestDto, string userId, List<String> userRoleClaims);
        Task<Boolean> DeleteAsync(Guid id, string userId, List<String> userRoleClaims);
    }
}
