using Core.Entities;

namespace BLL.Interfaces
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetBookings();
        Booking GetBooking(Guid id);
        void UpdateBooking(Booking booking);
        void DeleteBooking(Guid id);
        void AddBooking(Booking booking);
    }
}
