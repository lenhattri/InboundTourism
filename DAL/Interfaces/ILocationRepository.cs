using System;
using System.Collections.Generic;
using Core.Entities;

namespace DAL.Interfaces
{
    public interface ILocationRepository
    {
      
        List<Location> GetAll();

        
        Location GetById(Guid id);

    
        void Add(Location location);

    
        void Update(Location location);

       
        void Delete(Guid id);

       
        IEnumerable<Location> Find(string locationName = null, string city = null, string country = null);
    }
}
