using Auth.Models.Domain;
using Auth.Models.DTOs;

namespace Auth.Services.Interface
{
    public interface ICommentService
    {
        Task<CommentDto?> CreateAsync(AddCommentRequestDto addCommentRequestDto, DateTime dateTime, string userId);
        Task<CommentDto?> GetByIdAsync(Guid id);
        Task<List<CommentDto>?> GetAllAsync();
        Task<CommentDto?> UpdateAsync(Guid id, UpdateCommentRequestDto updateCommentRequestDto, string userId, List<String> userRoleClaims);
        Task<Boolean> DeleteAsync(Guid id, string userId, List<String> userRoleClaims);
    }
}
