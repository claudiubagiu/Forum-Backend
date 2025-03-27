using Auth.Models.Domain;

namespace Auth.Repositories.Interface
{
    public interface IPostRepository
    {
        Task<Post> CreateAsync(Post post);
        Task<List<Post>> GetAllAsync();
        Task<Post?> GetByIdAsync(Guid id);
        Task<Post?> DeleteAsync(Guid id);
        Task<Post?> UpdateAsync(Post post);
    }
}
