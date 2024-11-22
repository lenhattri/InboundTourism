using System;
using System.Collections.Generic;
using Core.Entities;

namespace DAL.Interfaces
{
    public interface IBookingRepository
    {
        List<Booking> GetAll();
        Booking GetById(Guid bookingId);
        void Add(Booking booking);
        void Update(Booking booking);
        void Delete(Guid bookingId);
        IEnumerable<Booking> FindByUserId(Guid userId);
        IEnumerable<Booking> FindByTripId(Guid tripId);
        IEnumerable<Booking> Find(DateTime? startDate = null, DateTime? endDate = null);
    }
}
