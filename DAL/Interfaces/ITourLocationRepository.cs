using System;
using System.Collections.Generic;
using Core.Entities;

namespace DAL.Interfaces
{
    public interface ITourLocationRepository
    {
        List<TourLocation> GetAll();
        TourLocation GetByTourAndLocationId(Guid tourId, Guid locationId);
        void Add(TourLocation tourLocation);
        void Update(TourLocation tourLocation);
        void Delete(Guid tourId, Guid locationId);
        IEnumerable<TourLocation> FindByTourId(Guid tourId);
        IEnumerable<TourLocation> FindByLocationId(Guid locationId);
    }
}
