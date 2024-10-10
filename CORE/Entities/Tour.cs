using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Tour
    {
        public int TourID { get; set; }
        public string TourName { get; set; }
        public string Description { get; set; }
        //public decimal BasePrice { get; set; }

        public ICollection<Trip> Trips { get; set; }
        public ICollection<TourLocation> TourLocations { get; set; }
    }

}
