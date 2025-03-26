namespace Auth.Models.Domain
{
    public class ImagePost : Image
    {
        public required Guid PostId { get; set; }
        public Post Post { get; set; } = null!;
    }
}
