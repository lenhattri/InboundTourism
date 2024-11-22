using System;
using System.Collections.Generic;
using Core.Entities;

namespace DAL.Interfaces
{
    public interface ITripRepository
    {
        List<Trip> GetAll();
        Trip GetById(Guid tripId);
        void Add(Trip trip);
        void Update(Trip trip);
        void Delete(Guid tripId);
        IEnumerable<Trip> FindByTourId(Guid tourId);
        IEnumerable<Trip> Find(DateTime? startDate = null, DateTime? endDate = null, decimal? maxPrice = null);
    }
}
