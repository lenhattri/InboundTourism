using System;

namespace Views.DTO
{
    public class BookingViewModel
    {
        public Guid BookingID { get; set; }
        public Guid TripID { get; set; }     
        public Guid UserID { get; set; }    
        public string TripName { get; set; }
        public string UserName { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
