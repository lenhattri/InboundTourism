using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Location
    {
        [Key]
        public Guid LocationID { get; set; } = Guid.NewGuid();

        [Required]
        public string LocationName { get; set; }

        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string? ImageUrl { get; set; }
        // Navigation property: Một location có thể thuộc nhiều tour
        [JsonIgnore]
        public ICollection<TourLocation>? TourLocations { get; set; }
    }
}
