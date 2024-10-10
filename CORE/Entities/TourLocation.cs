

namespace Core.Entities
{
    public class TourLocation
    {
        public int TourID { get; set; }
        public Tour Tour { get; set; }

        public int LocationID { get; set; }
        public Location Location { get; set; }

        public int VisitOrder { get; set; }
    }

}
