using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Core.Enums;

namespace Core.Entities
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; } = Guid.NewGuid();

        [Required]
        public Role Role { get; set; } = Role.Customer;

        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Address { get; set; }


        // Navigation property: Một user có nhiều booking
        [JsonIgnore]
        public ICollection<Booking>? Bookings { get; set; }
    }
}
