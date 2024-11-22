using BLL.Interfaces;
using Core.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;

        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public IEnumerable<Trip> GetTrips()
        {
            return _tripRepository.GetAll();
        }

        public Trip GetTripById(Guid tripId)
        {
            return _tripRepository.GetById(tripId);
        }

        public void AddTrip(Trip trip)
        {
            _tripRepository.Add(trip);
        }

        public void UpdateTrip(Trip trip)
        {
            _tripRepository.Update(trip);
        }

        public void DeleteTrip(Guid tripId)
        {
            _tripRepository.Delete(tripId);
        }

        public IEnumerable<Trip> FindTripsByTourId(Guid tourId)
        {
            return _tripRepository.FindByTourId(tourId);
        }

        public IEnumerable<Trip> FindTrips(DateTime? startDate = null, DateTime? endDate = null, decimal? maxPrice = null)
        {
            return _tripRepository.Find(startDate, endDate, maxPrice);
        }
    }
}
