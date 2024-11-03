

using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class TourLocation
    {
        public Guid TourID { get; set; }
        public Tour Tour { get; set; } // Khóa ngoại

        public Guid LocationID { get; set; }
        public Location Location { get; set; } // Khóa ngoại

        public int VisitOrder { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

}
