using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Tour
    {
        [Key]
        public Guid TourID { get; set; } = Guid.NewGuid();

        [Required]
        public string TourName { get; set; }

        public string Description { get; set; }

        // Navigation property: Một tour có nhiều trip
        [JsonIgnore]
        public ICollection<Trip>? Trips { get; set; }

        // Navigation property: Một tour đi qua nhiều location
        [JsonIgnore]
        public ICollection<TourLocation>? TourLocations { get; set; }
    }
}
