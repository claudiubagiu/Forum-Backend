using System.ComponentModel;

namespace Auth.Models.Domain
{
    public enum Status
    {
        [Description("Received")]
        Received,

        [Description("In Progress")]
        InProgress,

        [Description("Resolved")]
        Resolved
    }
    public class Post
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required DateTime CreatedAt { get; set; } 
        public required Status Status { get; set; }
        public required string UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public List<Tag> Tags { get; } = [];
        public ImagePost? Image { get; set; }
        public ICollection<VotePost> Votes { get; set; } = new List<VotePost>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
