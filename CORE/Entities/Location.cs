using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Location
    {
        public Guid LocationID { get; set; }
        public string LocationName { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        // Khóa ngoại
        public ICollection<TourLocation>? TourLocations { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

}
