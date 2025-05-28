using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class TourLocationRepository : ITourLocationRepository
    {
        private readonly AppDbContext _context;

        public TourLocationRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<TourLocation> GetAll()
        {
            return _context.TourLocations.ToList();
        }

        public TourLocation GetByTourAndLocationId(Guid tourId, Guid locationId)
        {
            return _context.TourLocations.FirstOrDefault(tl => tl.TourID == tourId && tl.LocationID == locationId);
        }

        public void Add(TourLocation tourLocation)
        {
            _context.TourLocations.Add(tourLocation);
            _context.SaveChanges();
        }

        public void Update(TourLocation tourLocation)
        {
            _context.TourLocations.Update(tourLocation);
            _context.SaveChanges();
        }

        public void Delete(Guid tourId, Guid locationId)
        {
            var entity = _context.TourLocations.FirstOrDefault(tl => tl.TourID == tourId && tl.LocationID == locationId);
            if (entity != null)
            {
                _context.TourLocations.Remove(entity);
                _context.SaveChanges();
            }
        }

        public IEnumerable<TourLocation> FindByTourId(Guid tourId)
        {
            return _context.TourLocations.Where(tl => tl.TourID == tourId).ToList();
        }

        public IEnumerable<TourLocation> FindByLocationId(Guid locationId)
        {
            return _context.TourLocations.Where(tl => tl.LocationID == locationId).ToList();
        }
    }
}
