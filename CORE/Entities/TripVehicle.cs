using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TripVehicle
    {
        public int TripVehicleID { get; set; }
        public int TripID { get; set; }
        public int VehicleID { get; set; }
        public DateTime USageStartTime { get; set; }
        public DateTime USageEndTime { get; set; }

        
    }
}
