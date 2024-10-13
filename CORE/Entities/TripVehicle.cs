using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TripVehicle
    {
        public Guid TripVehicleID { get; set; }
        public Guid TripID { get; set; }
        public Guid VehicleID { get; set; }
        public DateTime USageStartTime { get; set; }
        public DateTime USageEndTime { get; set; }

        
    }
}
