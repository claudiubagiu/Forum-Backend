using Auth.Models.Domain;

namespace Auth.Repositories.Interface
{
    public interface IApplicationUserRepository
    {
        Task<List<ApplicationUser>> GetAllAsync();
        Task<ApplicationUser> GetByIdAsync(string id);
    }
}
