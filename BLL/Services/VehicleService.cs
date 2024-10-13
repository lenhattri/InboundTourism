using BLL.Interfaces;
using Core.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IGenericRepository<Vehicle> _vehicleRepository;

        public VehicleService(IGenericRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return _vehicleRepository.GetAll();
        }

        public Vehicle GetVehicle(Guid id)
        {
            return _vehicleRepository.GetById(id);
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            _vehicleRepository.Update(vehicle);
        }

        public void DeleteVehicle(Guid id)
        {
            _vehicleRepository.Delete(id);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _vehicleRepository.Add(vehicle);
        }
    }
}
