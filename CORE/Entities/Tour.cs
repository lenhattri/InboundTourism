using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Tour
    {
        public Guid TourID { get; set; } //Khóa ngoại
        public string TourName { get; set; }
        public string Description { get; set; }
        //public decimal BasePrice { get; set; }


        //Khóa ngoại
        public ICollection<Trip> Trips { get; set; }
        public ICollection<TourLocation> TourLocations { get; set; }
    }

}
