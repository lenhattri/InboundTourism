using Core.Entities;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ITourService
    {
        IEnumerable<Tour> GetTours();
        Tour GetTour(Guid id);
        void AddTour(Tour tour, List<Guid> locationIds);
        public void UpdateTour(Tour tour, List<Guid> locationIds);
        void DeleteTour(Guid id);
        IEnumerable<Tour> FindTours(string tourName = null);
    }
}


