

using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class TripVehicle
    {
        public Guid TripVehicleID { get; set; }
        public Guid TripID { get; set; }
        public Guid VehicleID { get; set; }
        public DateTime USageStartTime { get; set; }
        public DateTime USageEndTime { get; set; }
        //Set up timestamp
        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
