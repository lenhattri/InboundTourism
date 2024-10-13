using BLL.Interfaces;
using Core.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IGenericRepository<Booking> _bookingRepository;

        public BookingService(IGenericRepository<Booking> bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public IEnumerable<Booking> GetBookings()
        {
            return _bookingRepository.GetAll();
        }

        public Booking GetBooking(Guid id)
        {
            return _bookingRepository.GetById(id);
        }

        public void UpdateBooking(Booking booking)
        {
            _bookingRepository.Update(booking);
        }

        public void DeleteBooking(Guid id)
        {
            _bookingRepository.Delete(id);
        }

        public void AddBooking(Booking booking)
        {
            _bookingRepository.Add(booking);
        }
    }
}
