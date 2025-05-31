using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Booking> GetAll()
        {
            return _context.Bookings.ToList();
        }

        public Booking GetById(Guid bookingId)
        {
            return _context.Bookings.Find(bookingId);
        }

        public void Add(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public void Update(Booking booking)
        {
            
            var tracked = _context.Bookings.Find(booking.BookingID);
            if (tracked == null)
                throw new Exception("Booking không tồn tại.");
            
            _context.Entry(tracked).CurrentValues.SetValues(booking);
            _context.SaveChanges();
        }

        public void Delete(Guid bookingId)
        {
            var booking = _context.Bookings.Find(bookingId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Booking> FindByUserId(Guid userId)
        {
            return _context.Bookings.Where(b => b.UserID == userId).ToList();
        }

        public IEnumerable<Booking> FindByTripId(Guid tripId)
        {
            return _context.Bookings.Where(b => b.TripID == tripId).ToList();
        }

        public IEnumerable<Booking> Find(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.Bookings.AsQueryable();
            if (startDate.HasValue)
                query = query.Where(b => b.BookingDate >= startDate.Value);
            if (endDate.HasValue)
                query = query.Where(b => b.BookingDate <= endDate.Value);
            return query.ToList();
        }
    }
}
