namespace Auth.Models.Domain
{
    public class ImageComment : Image
    {
        public required Guid CommentId { get; set; }
        public Comment Comment { get; set; } = null!;
    }
}
