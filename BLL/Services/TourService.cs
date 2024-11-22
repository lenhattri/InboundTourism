using BLL.Interfaces;
using Core.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepository;
        private readonly ITourLocationRepository _tourLocationRepository;

        public TourService(ITourRepository tourRepository, ITourLocationRepository tourLocationRepository)
        {
            _tourRepository = tourRepository;
            _tourLocationRepository = tourLocationRepository;
        }

        public IEnumerable<Tour> GetTours()
        {
            return _tourRepository.GetAll();
        }

        public Tour GetTour(Guid id)
        {
            return _tourRepository.GetById(id);
        }

        public void AddTour(Tour tour ,List<Guid> locationIds)
        {
            _tourRepository.Add(tour);

            int index = 0;
            foreach (var locationId in locationIds)
            {

                var tourLocation = new TourLocation
                {
                    TourID = tour.TourID,
                    LocationID = locationId,
                    LocationIndex = index++
                };
                _tourLocationRepository.Add(tourLocation);
            }
        }

        public void UpdateTour(Tour tour)
        {
            _tourRepository.Update(tour);
        }

        public void DeleteTour(Guid id)
        {
            var tourLocations = _tourLocationRepository.FindByTourId(id);
            foreach (var tourLocation in tourLocations)
            {
                _tourLocationRepository.Delete(tourLocation.TourID, tourLocation.LocationID);
            }

            _tourRepository.Delete(id);
        }

        public IEnumerable<Tour> FindTours(string tourName = null)
        {
            return _tourRepository.Find(tourName);
        }
    }
}
