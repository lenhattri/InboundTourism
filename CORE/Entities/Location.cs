using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Location
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        // Relationships
        public ICollection<TourLocation> TourLocations { get; set; }
    }

}
