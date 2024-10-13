using BLL.Interfaces;
using Core.Entities;

using DAL.Interfaces;
namespace BLL.Services
{
    public class TripService : ITripService
    {

        private readonly IGenericRepository<Trip> _tripRepository;
        private readonly IGenericRepository<Booking> _BookingRepository;
        public TripService(IGenericRepository<Trip> tripRepository)
        {
            _tripRepository = tripRepository;
        }
        public IEnumerable<Trip> GetTrips()
        {
            return _tripRepository.GetAll();
        }
        public Trip GetTrip(Guid id)
        {
            return _tripRepository.GetById(id);
        }

        public void UpdateTrip(Trip Trip)
        {
            _tripRepository.Update(Trip);
        }
        public void DeleteTrip(Guid id)
        {
            _tripRepository.Delete(id);
        }
        public void AddTrip(Trip Trip)
        {
            _tripRepository.Add(Trip);

        }


    }
}
