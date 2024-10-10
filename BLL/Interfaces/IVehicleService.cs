using Core.Entities;

namespace BLL.Interfaces
{
    public interface IVehicleService
    {
        IEnumerable<Vehicle> GetVehicles();
        Vehicle GetVehicle(int id);
        void UpdateVehicle(Vehicle vehicle);
        void DeleteVehicle(int id);
        void AddVehicle(Vehicle vehicle);
    }
}
