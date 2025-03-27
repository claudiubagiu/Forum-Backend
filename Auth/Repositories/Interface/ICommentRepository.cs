using Auth.Models.Domain;

namespace Auth.Repositories.Interface
{
    public interface ICommentRepository
    {
        Task<Comment> CreateAsync(Comment comment);
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(Guid id);
        Task<Comment?> DeleteAsync(Guid id);
        Task<Comment?> UpdateAsync(Comment comment);
    }
}
