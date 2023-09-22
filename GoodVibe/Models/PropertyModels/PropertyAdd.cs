namespace GoodVibe.Models.PropertyModels
{
    public class PropertyAdd : Property
    {
        public string? HouseNo { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PinCode { get; set; }
        public int Sqft { get; set; }
        public double Price { get; set; }
        public string Details { get; set; }
        public string? ImageUrl { get; set; }
    }
}
