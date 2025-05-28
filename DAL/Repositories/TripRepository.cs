using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly AppDbContext _context;

        public TripRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Trip> GetAll()
        {
            return _context.Trips.ToList();
        }

        public Trip GetById(Guid tripId)
        {
            return _context.Trips.Find(tripId);
        }

        public void Add(Trip trip)
        {
            _context.Trips.Add(trip);
            _context.SaveChanges();
        }

        public void Update(Trip trip)
        {
            _context.Trips.Update(trip);
            _context.SaveChanges();
        }

        public void Delete(Guid tripId)
        {
            var trip = _context.Trips.Find(tripId);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Trip> FindByTourId(Guid tourId)
        {
            return _context.Trips.Where(t => t.TourID == tourId).ToList();
        }

        public IEnumerable<Trip> Find(DateTime? startDate = null, DateTime? endDate = null, decimal? maxPrice = null)
        {
            var query = _context.Trips.AsQueryable();

            if (startDate.HasValue)
                query = query.Where(t => t.StartDate >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(t => t.EndDate <= endDate.Value);

            if (maxPrice.HasValue)
                query = query.Where(t => t.Price <= maxPrice.Value);

            return query.ToList();
        }
    }
}
