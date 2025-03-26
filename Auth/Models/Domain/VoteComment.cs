namespace Auth.Models.Domain
{
    public class VoteComment : Vote
    {
        public required Guid CommentId { get; set; }
        public Comment Comment { get; set; } = null!;
        public required string UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
    }
}
