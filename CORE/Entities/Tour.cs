
namespace Core.Entities
{
    public class Tour
    {
        public Guid TourID { get; set; } = Guid.NewGuid();
        public string TourName { get; set; }
        public string Description { get; set; }

    }


}
