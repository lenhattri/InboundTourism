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
        private readonly ITripRepository _tripRepository;

        public TourService(ITourRepository tourRepository, ITourLocationRepository tourLocationRepository,ITripRepository tripRepository)
        {
            _tourRepository = tourRepository;
            _tourLocationRepository = tourLocationRepository;
            _tripRepository = tripRepository;
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

        public void UpdateTour(Tour tour, List<Guid> locationIds)
        {
            _tourRepository.Update(tour);

            //Xóa các TourLocation cũ
            var existingTourLocations = _tourLocationRepository.FindByTourId(tour.TourID);
            foreach (var tourLocation in existingTourLocations)
            {
                _tourLocationRepository.Delete(tourLocation.TourID, tourLocation.LocationID);
            }

            //Thêm TourLocation mới
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


        public void DeleteTour(Guid id)
        {
            var tourLocations = _tourLocationRepository.FindByTourId(id);
            foreach (var tourLocation in tourLocations)
            {
                _tourLocationRepository.Delete(tourLocation.TourID, tourLocation.LocationID);
            }
            var trips = _tripRepository.FindByTourId(id);
            foreach (var trip in trips)
            {
                _tripRepository.Delete(trip.TripID);
            }
            _tourRepository.Delete(id);
        }

        public IEnumerable<Tour> FindTours(string tourName = null)
        {
            return _tourRepository.Find(tourName);
        }
    }
}
