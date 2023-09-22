using System.ComponentModel.DataAnnotations;

namespace GoodVibe.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "House No is required"), StringLength(25, ErrorMessage = "Maximum Length")]
        public string? HouseNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Area is required"), StringLength(50, ErrorMessage = "Maximum Length")]
        public string Area { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required"), StringLength(50, ErrorMessage = "Maximum Length")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "State is required"), StringLength(100, ErrorMessage = "Maximum Length")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "Pin Code is required"), MinLength(100000, ErrorMessage = "Minimum Length")]
        public int PinCode { get; set; }

        [Required(ErrorMessage = "Area size is required")]
        public int Sqft { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Details is required"), StringLength(150, ErrorMessage = "Maximum Length")]
        public string Details { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
