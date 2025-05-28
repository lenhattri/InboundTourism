namespace API.DTO
{
    public class LocationUpdateDto
    {
        public Guid LocationID { get; set; }
        public string LocationName { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string? ImageUrl { get; set; }
    }

}
