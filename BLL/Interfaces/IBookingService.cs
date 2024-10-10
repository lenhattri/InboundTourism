using Core.Entities;

namespace BLL.Interfaces
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetBookings();
        Booking GetBooking(int id);
        void UpdateBooking(Booking booking);
        void DeleteBooking(int id);
        void AddBooking(Booking booking);
    }
}
