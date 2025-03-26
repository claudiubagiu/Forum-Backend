namespace Auth.Models.Domain
{
    public class Comment
    {
        public required Guid Id { get; set; }
        public required string Description { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required string UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public required Guid PostId { get; set; }
        public Post Post { get; set; } = null!;
        public ImageComment? Image { get; set; }
        public ICollection<VoteComment> Votes { get; set; } = new List<VoteComment>();

    }
}
