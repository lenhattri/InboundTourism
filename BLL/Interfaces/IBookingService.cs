using Core.Entities;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetBookings();
        Booking GetBookingById(Guid bookingId);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(Guid bookingId);
        IEnumerable<Booking> FindBookingsByUserId(Guid userId);
        IEnumerable<Booking> FindBookingsByTripId(Guid tripId);
        IEnumerable<Booking> FindBookings(DateTime? startDate = null, DateTime? endDate = null);
    }
}
