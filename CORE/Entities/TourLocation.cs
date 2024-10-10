

namespace Core.Entities
{
    public class TourLocation
    {
        public int TourID { get; set; }
        public Tour Tour { get; set; } // Khóa ngoại

        public int LocationID { get; set; }
        public Location Location { get; set; } // Khóa ngoại

        public int VisitOrder { get; set; }
    }

}
