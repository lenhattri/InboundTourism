

namespace Core.Entities
{
    public class Trip
    {
        public Guid TripID { get; set; } = Guid.NewGuid();
        public Guid TourID { get; set; }

        public string? TourName { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public double Distance {  get; set; }
        public int MaxGuests { get; set; }


    }

}
