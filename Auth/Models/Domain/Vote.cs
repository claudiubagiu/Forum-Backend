using System.ComponentModel;

namespace Auth.Models.Domain
{
    public enum Type
    {
        [Description("Like")]
        Like,

        [Description("Dislike")]
        Dislike
    }
    public abstract class Vote
    {
        public required Guid Id { get; set; }
        public required Type Type { get; set; }
    }
}
