using Auth.Models.Domain;

namespace Auth.Models.DTOs
{
    public class AddCommentRequestDto
    {
        public required string Description { get; set; }
        public Guid? CommentId { get; set; }
        public Guid? PostId { get; set; }

    }
}
