using BLL.Interfaces;
using Core.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class TourLocationService : ITourLocationService
    {
        private readonly ITourLocationRepository _tourLocationRepository;

        public TourLocationService(ITourLocationRepository tourLocationRepository)
        {
            _tourLocationRepository = tourLocationRepository;
        }

        public IEnumerable<TourLocation> GetAllTourLocations()
        {
            return _tourLocationRepository.GetAll();
        }

        public TourLocation GetTourLocation(Guid tourId, Guid locationId)
        {
            return _tourLocationRepository.GetByTourAndLocationId(tourId, locationId);
        }

        public void AddTourLocation(TourLocation tourLocation)
        {
            _tourLocationRepository.Add(tourLocation);
        }

        public void UpdateTourLocation(TourLocation tourLocation)
        {
            _tourLocationRepository.Update(tourLocation);
        }

        public void DeleteTourLocation(Guid tourId, Guid locationId)
        {
            _tourLocationRepository.Delete(tourId, locationId);
        }

        public IEnumerable<TourLocation> FindByTourId(Guid tourId)
        {
            return _tourLocationRepository.FindByTourId(tourId);
        }

        public IEnumerable<TourLocation> FindByLocationId(Guid locationId)
        {
            return _tourLocationRepository.FindByLocationId(locationId);
        }
    }
}
