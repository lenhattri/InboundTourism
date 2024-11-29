

namespace Core.Entities
{
    public class Booking
    {
        public Guid BookingID { get; set; } = Guid.NewGuid();

        public Guid TripID { get; set; }


        public Guid UserID { get; set; }


        public DateTime BookingDate { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal TotalPrice { get; set; }


    }

}
