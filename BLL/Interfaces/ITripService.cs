using Core.Entities;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ITripService
    {
        IEnumerable<Trip> GetTrips();
        Trip GetTripById(Guid tripId);
        void AddTrip(Trip trip);
        void UpdateTrip(Trip trip);
        void DeleteTrip(Guid tripId);
        IEnumerable<Trip> FindTripsByTourId(Guid tourId);
        IEnumerable<Trip> FindTrips(DateTime? startDate = null, DateTime? endDate = null, decimal? maxPrice = null);
    }
}
