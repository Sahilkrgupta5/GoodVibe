using System.ComponentModel.DataAnnotations;

namespace GoodVibe.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string EmailId { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;

        public string? UserMessage { get; set; }
        public string? AccessToken { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
