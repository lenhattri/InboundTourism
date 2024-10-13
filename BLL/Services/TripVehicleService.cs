using BLL.Interfaces;
using Core.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TripVehicleService : ITripVehicleService
    {
        private readonly IGenericRepository<TripVehicle> _tripVehicleRepository;

        public TripVehicleService(IGenericRepository<TripVehicle> tripVehicleRepository)
        {
            _tripVehicleRepository = tripVehicleRepository;
        }

        public IEnumerable<TripVehicle> GetTripVehicles()
        {
            return _tripVehicleRepository.GetAll();
        }

        public TripVehicle GetTripVehicle(Guid id)
        {
            return _tripVehicleRepository.GetById(id);
        }

        public void UpdateTripVehicle(TripVehicle tripVehicle)
        {
            _tripVehicleRepository.Update(tripVehicle);
        }

        public void DeleteTripVehicle(Guid id)
        {
            _tripVehicleRepository.Delete(id);
        }

        public void AddTripVehicle(TripVehicle tripVehicle)
        {
            _tripVehicleRepository.Add(tripVehicle);
        }
    }
}
