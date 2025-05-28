using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class TourLocation
    {
        [Key, Column(Order = 0)]
        public Guid TourID { get; set; }
        [JsonIgnore]
        [ForeignKey("TourID")]
        public Tour? Tour { get; set; }

        [Key, Column(Order = 1)]
        public Guid LocationID { get; set; }
        [ForeignKey("LocationID")]
        [JsonIgnore]
        public Location? Location { get; set; }

        // Vị trí của location trong tour (thứ tự)
        [Key, Column(Order = 2)]
        public int LocationIndex { get; set; }
    }
}
