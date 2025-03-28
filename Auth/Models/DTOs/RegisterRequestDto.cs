﻿using System.ComponentModel.DataAnnotations;

namespace Auth.Models.DTOs
{
    public class RegisterRequestDto
    {
        [EmailAddress]
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public required string UserName { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
