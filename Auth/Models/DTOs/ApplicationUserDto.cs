namespace Auth.Models.DTOs
{
    public class ApplicationUserDto
    {
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public int Score { get; set; }

    }
}
