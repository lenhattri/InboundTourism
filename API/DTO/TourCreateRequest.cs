namespace API.DTO
{
    public class TourCreateRequest
    {
        public string TourName { get; set; }
        public string Description { get; set; }
        public List<Guid> LocationIds { get; set; }
    }
}