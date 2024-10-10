using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Trip
    {
        public int TripID { get; set; }
        public int TourID { get; set; }
        public Tour Tour { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public double Distance {  get; set; }
        public int MaxGuests { get; set; }

        public ICollection<Vehicle>? Vehicles { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
        
    }

}
