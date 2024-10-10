﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int TripID { get; set; }
        public Trip Trip { get; set; }

        public int CustomerID { get; set; }
        public User User { get; set; }

        public DateTime BookingDate { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
