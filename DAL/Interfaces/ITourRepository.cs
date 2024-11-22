using System;
using System.Collections.Generic;
using Core.Entities;

namespace DAL.Interfaces
{
    public interface ITourRepository
    {
        List<Tour> GetAll();
        Tour GetById(Guid id);
        void Add(Tour tour);
        void Update(Tour tour);
        void Delete(Guid id);
        IEnumerable<Tour> Find(string tourName = null);
    }
}
