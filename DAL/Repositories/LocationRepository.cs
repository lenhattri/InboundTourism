using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _context;

        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Location> GetAll()
        {
            return _context.Locations.ToList();
        }

        public Location GetById(Guid id)
        {
            return _context.Locations.Find(id);
        }

        public void Add(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
        }

        public void Update(Location location)
        {
            _context.Locations.Update(location);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var location = _context.Locations.Find(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Location> Find(string locationName = null, string city = null, string country = null)
        {
            IQueryable<Location> query = _context.Locations;

            if (!string.IsNullOrEmpty(locationName))
                query = query.Where(l => EF.Functions.Like(l.LocationName, $"%{locationName}%"));
            if (!string.IsNullOrEmpty(city))
                query = query.Where(l => EF.Functions.Like(l.City, $"%{city}%"));
            if (!string.IsNullOrEmpty(country))
                query = query.Where(l => EF.Functions.Like(l.Country, $"%{country}%"));

            return query.ToList();
        }
    }
}
