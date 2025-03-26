namespace Auth.Models.Domain
{
    public class Tag
    {
        public required Guid Id { get; set; }
        public List<Post> Posts { get; } = [];
    }
}
