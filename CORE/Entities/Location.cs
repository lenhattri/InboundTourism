using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Location
    {
        public Guid LocationID { get; set; } = Guid.NewGuid();
        public string LocationName { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

     
        public Location() { }

    
        public Location(Guid locationID, string locationName, string description, string city, string country)
        {
            LocationID = locationID;
            LocationName = locationName;
            Description = description;
            City = city;
            Country = country;
        }
    }
}
