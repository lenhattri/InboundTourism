using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TourLocationRepository
    {

        private readonly AppDbContext _context;
        private readonly DbSet<TourLocation> _dbSet;
        public TourLocationRepository(AppDbContext context) { 
        
            _context = context;
            _dbSet = _context.Set<TourLocation>();
        }
        public IEnumerable<TourLocation> GetAll()
        {
            return _dbSet.ToList();
        }
        public TourLocation Get(int TourID,int LocationID) {
            return _dbSet.SingleOrDefault(tl => tl.TourID == TourID && tl.LocationID == LocationID);
        }
        public void Update(TourLocation tourLocation)
        {
            _dbSet.Add(tourLocation);
            _context.SaveChanges();

        }
        public void Delete(int TourID, int LocationID)
        {
            TourLocation entity = _dbSet.SingleOrDefault(tl => tl.TourID == TourID && tl.LocationID == LocationID);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"TourLocation với TourID {TourID} và LocationID {LocationID} không tồn tại.");
            }
        }

    }
}
