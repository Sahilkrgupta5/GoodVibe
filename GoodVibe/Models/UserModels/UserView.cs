namespace GoodVibe.Models.UserModels
{
    public class UserView : User
    {
        public string? Name { get; set; }
        public string EmailId { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
