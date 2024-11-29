namespace API.DTO
{
    public class TripDetailDTO
    {
        public Guid TripID { get; set; }
        public string TourName { get; set; } 
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Distance { get; set; }
        public int MaxGuests { get; set; }
    }

}
