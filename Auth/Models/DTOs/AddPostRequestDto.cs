using Auth.Models.Domain;
using System.ComponentModel;

namespace Auth.Models.DTOs
{
    public class AddPostRequestDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required Status Status { get; set; }
    }
}
