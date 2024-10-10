using Core.Enums;
namespace Core.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public Role Role { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        

        // Relationships
        public ICollection<Booking> Bookings { get; set; }
    }

}
