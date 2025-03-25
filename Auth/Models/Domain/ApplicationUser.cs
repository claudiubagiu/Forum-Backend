using Microsoft.AspNetCore.Identity;

namespace Auth.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public required String FirstName { get; set; }
        public required String LastName { get; set; }
        public int Score { get; set; } = 0;
    }
}
