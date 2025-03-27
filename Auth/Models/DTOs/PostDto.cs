using Auth.Models.Domain;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Auth.Models.DTOs
{
    public enum Status
    {
        [Description("Received")]
        Received,

        [Description("Ongoing")]
        Ongoing,

        [Description("Resolved")]
        Resolved
    }
    public class PostDto
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required DateTime CreatedAt { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required Status Status { get; set; }
        public required string UserId { get; set; }
        public ApplicationUserDto User { get; set; } = null!;
        public List<Tag> Tags { get; } = [];
        public Image? Image { get; set; }
        public ICollection<Vote> Votes { get; set; } = new List<Vote>();
        //public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
