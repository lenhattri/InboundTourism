using Core.Entities;
using System.Collections.Generic;

namespace Web.Models
{
    public class TourWithLocations
    {
        public Tour Tour { get; set; }
        public List<Location> Locations { get; set; }
    }
}
