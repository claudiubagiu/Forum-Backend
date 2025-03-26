using Auth.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Auth.Data
{
    public class BackendDbContext : IdentityDbContext<ApplicationUser>
    {
        public BackendDbContext(DbContextOptions<BackendDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var userRoleId = "430f06bf-f5cd-4d94-87f5-cb9575698d74";
            var adminRoleId = "d251e4e9-a928-48da-aa5d-720eaa10789c";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = "User",
                    NormalizedName = "USER".ToUpper()
                },
                new IdentityRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);


            builder.Entity<Post>()
                   .HasMany(e => e.Tags)
                   .WithMany(e => e.Posts);

            builder.Entity<Post>()
                   .HasMany(e => e.Votes)
                   .WithOne(e => e.Post)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Post>()
                   .HasOne(e => e.Image)
                   .WithOne(e => e.Post)
                   .HasForeignKey<ImagePost>(e => e.PostId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Post>()
                   .HasMany(e => e.Comments)
                   .WithOne(e => e.Post)
                   .HasForeignKey(e => e.PostId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Post>()
                   .Property(e => e.Status)
                   .HasConversion<string>();

            builder.Entity<Comment>()
                   .HasMany(e => e.Votes)
                   .WithOne(e => e.Comment)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comment>()
                   .HasOne(e => e.Image)
                   .WithOne(e => e.Comment)
                   .HasForeignKey<ImageComment>(e => e.CommentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
                   .HasMany(e => e.Comments)
                   .WithOne(e => e.User)
                   .HasForeignKey(e => e.UserId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ApplicationUser>()
                   .HasMany(e => e.VotesComments)
                   .WithOne(e => e.User)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ApplicationUser>()
                   .HasMany(e => e.VotesPosts)
                   .WithOne(e => e.User)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ApplicationUser>()
                   .HasMany(e => e.Posts)
                   .WithOne(e => e.User)
                   .HasForeignKey(e => e.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
                   .HasOne(e => e.Ban)
                   .WithOne(e => e.User)
                   .HasForeignKey<Ban>(e => e.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<VotePost>()
                   .Property(e => e.Type)
                   .HasConversion<string>();

            builder.Entity<VoteComment>()
                   .Property(e => e.Type)
                   .HasConversion<string>();
        }
    }
}
