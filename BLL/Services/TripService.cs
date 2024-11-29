using BLL.Interfaces;
using Core.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        private readonly ITourRepository _tourRepository; // Thêm repository của Tour

        public TripService(ITripRepository tripRepository, ITourRepository tourRepository)
        {
            _tripRepository = tripRepository;
            _tourRepository = tourRepository;
        }

        public IEnumerable<Trip> GetTrips()
        {
            var trips = _tripRepository.GetAll();
            return FormatTripsWithTourName(trips);
        }

        public Trip GetTripById(Guid tripId)
        {
            var trip = _tripRepository.GetById(tripId);
            if (trip != null)
            {
                var tour = _tourRepository.GetById(trip.TourID);
                if (tour != null)
                {
                    trip.TourName = FormatTourName(trip, tour.TourName);
                }
            }
            return trip;
        }

        public void AddTrip(Trip trip)
        {
            // Thêm TourName trước khi lưu
            var tour = _tourRepository.GetById(trip.TourID);
            if (tour != null)
            {
                trip.TourName = FormatTourName(trip, tour.TourName);
            }
            _tripRepository.Add(trip);
        }

        public void UpdateTrip(Trip trip)
        {
            // Cập nhật TourName khi sửa
            var tour = _tourRepository.GetById(trip.TourID);
            if (tour != null)
            {
                trip.TourName = FormatTourName(trip, tour.TourName);
            }
            _tripRepository.Update(trip);
        }

        public void DeleteTrip(Guid tripId)
        {
            _tripRepository.Delete(tripId);
        }

        public IEnumerable<Trip> FindTripsByTourId(Guid tourId)
        {
            var trips = _tripRepository.FindByTourId(tourId);
            return FormatTripsWithTourName(trips);
        }

        public IEnumerable<Trip> FindTrips(DateTime? startDate = null, DateTime? endDate = null, decimal? maxPrice = null)
        {
            var trips = _tripRepository.Find(startDate, endDate, maxPrice);
            return FormatTripsWithTourName(trips);
        }

        // Private helper methods

        private IEnumerable<Trip> FormatTripsWithTourName(IEnumerable<Trip> trips)
        {
            
            var tours = _tourRepository.GetAll().ToDictionary(t => t.TourID);

            foreach (var trip in trips)
            {
                if (tours.TryGetValue(trip.TourID, out var tour))
                {
                    trip.TourName = FormatTourName(trip, tour.TourName);
                }
            }

            return trips;
        }

        private string FormatTourName(Trip trip, string tourName)
        {
           
            return $"{tourName}_{trip.StartDate:yyyyMMdd}_{trip.EndDate:yyyyMMdd}";
        }
    }
}
