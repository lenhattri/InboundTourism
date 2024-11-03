using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Entity của xe
    public class Vehicle
    {
        public Guid VehicleID { get; set; }
        public string VehicleType { get; set; }
        public string LicensePlate { get; set; }
        public int Capacity { get; set; }

        public decimal VehiclePricing { get; set; }
        //Khóa ngoại
        public ICollection<Trip> Trips { get; set; }


        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

}
