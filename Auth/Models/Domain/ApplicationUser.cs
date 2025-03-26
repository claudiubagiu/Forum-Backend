using Microsoft.AspNetCore.Identity;

namespace Auth.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public required String FirstName { get; set; }
        public required String LastName { get; set; }
        public int Score { get; set; } = 0;
        public Ban? Ban { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<VoteComment> VotesComments { get; set; } = new List<VoteComment>();
        public ICollection<VotePost> VotesPosts { get; set; } = new List<VotePost>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
