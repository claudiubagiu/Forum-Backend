namespace Auth.Models.Domain
{
    public class VotePost : Vote
    {
        public required Guid PostId { get; set; }
        public Post Post { get; set; } = null!;
        public required string UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
    }
}
