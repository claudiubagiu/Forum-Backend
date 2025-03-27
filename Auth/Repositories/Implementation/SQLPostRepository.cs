using Auth.Data;
using Auth.Models.Domain;
using Auth.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Auth.Repositories.Implementation
{
    public class SQLPostRepository : IPostRepository
    {
        private readonly BackendDbContext dbContext;

        public SQLPostRepository(BackendDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Post> CreateAsync(Post post)
        {
            await dbContext.Post.AddAsync(post);
            await dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post?> DeleteAsync(Guid id)
        {
            var post = await dbContext.Post.FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
            {
                return null;
            }
            dbContext.Post.Remove(post);
            await dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await dbContext.Post.Include("User").ToListAsync();
        }

        public async Task<Post?> GetByIdAsync(Guid id)
        {
            return await dbContext.Post.Include("User").Include("Tags").Include("Image").Include("Votes").Include("Comments").FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Post?> UpdateAsync(Post post)
        {
            var existingPost = await dbContext.Post.Include("User").Include("Tags").Include("Image").Include("Votes").Include("Comments").FirstOrDefaultAsync(p => p.Id == post.Id);

            if (existingPost == null)
            {
                return null;
            }

            dbContext.Entry(existingPost).CurrentValues.SetValues(post);

            await dbContext.SaveChangesAsync();
            return existingPost;
        }
    }
}
