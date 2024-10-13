using Core.Entities;

namespace BLL.Interfaces
{
    public interface IVehicleService
    {
        IEnumerable<Vehicle> GetVehicles();
        Vehicle GetVehicle(Guid id);
        void UpdateVehicle(Vehicle vehicle);
        void DeleteVehicle(Guid id);
        void AddVehicle(Vehicle vehicle);
    }
}
