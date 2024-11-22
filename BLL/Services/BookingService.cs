using BLL.Interfaces;
using Core.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public IEnumerable<Booking> GetBookings()
        {
            return _bookingRepository.GetAll();
        }

        public Booking GetBookingById(Guid bookingId)
        {
            return _bookingRepository.GetById(bookingId);
        }

        public void AddBooking(Booking booking)
        {
            _bookingRepository.Add(booking);
        }

        public void UpdateBooking(Booking booking)
        {
            _bookingRepository.Update(booking);
        }

        public void DeleteBooking(Guid bookingId)
        {
            _bookingRepository.Delete(bookingId);
        }

        public IEnumerable<Booking> FindBookingsByUserId(Guid userId)
        {
            return _bookingRepository.FindByUserId(userId);
        }

        public IEnumerable<Booking> FindBookingsByTripId(Guid tripId)
        {
            return _bookingRepository.FindByTripId(tripId);
        }

        public IEnumerable<Booking> FindBookings(DateTime? startDate = null, DateTime? endDate = null)
        {
            return _bookingRepository.Find(startDate, endDate);
        }
    }
}
