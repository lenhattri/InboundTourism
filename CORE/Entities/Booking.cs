using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Booking
    {
        [Key]
        public Guid BookingID { get; set; } = Guid.NewGuid();

        [Required]
        public Guid TripID { get; set; }
        [ForeignKey("TripID")]
        [JsonIgnore]
        public Trip? Trip { get; set; }

        [Required]
        public Guid UserID { get; set; }
        [ForeignKey("UserID")]
        [JsonIgnore]
        public User? User { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        public int NumberOfGuests { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
