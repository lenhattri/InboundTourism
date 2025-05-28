using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Trip
    {
        [Key]
        public Guid TripID { get; set; } = Guid.NewGuid();

        [Required]
        public Guid TourID { get; set; }
        [ForeignKey("TourID")]
        [JsonIgnore]
        public Tour? Tour { get; set; }

        [NotMapped]
        public string TourName { get; set; } 

        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public double Distance { get; set; }
        public int MaxGuests { get; set; }

        // Navigation property: Một trip có nhiều booking
        [JsonIgnore]
        public ICollection<Booking> Bookings { get; set; }
    }
}
