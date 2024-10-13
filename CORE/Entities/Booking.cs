using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Booking
    {
        public Guid BookingID { get; set; }
        public Guid TripID { get; set; }
        public Trip Trip { get; set; } //Khóa ngoại

        public int CustomerID { get; set; }
        public User User { get; set; } //Khóa ngoại

        public DateTime BookingDate { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
