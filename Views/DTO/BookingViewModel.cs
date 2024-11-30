using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Views.DTO
{
    public class BookingViewModel
    {
        public Guid BookingID { get; set; }
        public string TripName { get; set; }
        public string UserName { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
