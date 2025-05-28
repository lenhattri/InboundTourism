using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly AppDbContext _context;

        public TourRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Tour> GetAll()
        {
            return _context.Tours.ToList();
        }

        public Tour GetById(Guid id)
        {
            return _context.Tours.Find(id);
        }

        public void Add(Tour tour)
        {
            _context.Tours.Add(tour);
            _context.SaveChanges();
        }

        public void Update(Tour tour)
        {
            _context.Tours.Update(tour);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var tour = _context.Tours.Find(id);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Tour> Find(string tourName = null)
        {
            var query = _context.Tours.AsQueryable();
            if (!string.IsNullOrEmpty(tourName))
                query = query.Where(t => t.TourName.Contains(tourName));
            return query.ToList();
        }
    }
}
