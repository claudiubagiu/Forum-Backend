using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Models.Domain
{
    public abstract class Image
    {
        public required Guid Id { get; set; }
        [NotMapped]
        public required IFormFile File { get; set; }
        public required string FileName { get; set; }
        public string? FileDescription { get; set; }
        public required string FileExtension { get; set; }
        public required long FileSizeInBytes { get; set; }
        public required string FilePath { get; set; }

    }
}
