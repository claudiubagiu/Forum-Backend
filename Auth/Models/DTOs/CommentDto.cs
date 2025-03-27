using Auth.Models.Domain;
using System.Text.Json.Serialization;

namespace Auth.Models.DTOs
{
    public class CommentDto
    {
        public required Guid Id { get; set; }
        public required string Description { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required string UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public Guid PostId { get; set; }
        public Guid? CommentId { get; set; }
        //public Comment? ParentComment { get; set; }
        public ICollection<Comment> ChildrenComments { get; set; } = new List<Comment>();
        //public Post? Post { get; set; }
        public Image? Image { get; set; }
        public ICollection<Vote> Votes { get; set; } = new List<Vote>();

    }
}
