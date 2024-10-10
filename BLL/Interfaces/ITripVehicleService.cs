using Core.Entities;

namespace BLL.Interfaces
{
    public interface ITripVehicleService
    {
        IEnumerable<TripVehicle> GetTripVehicles();
        TripVehicle GetTripVehicle(int id);
        void UpdateTripVehicle(TripVehicle tripVehicle);
        void DeleteTripVehicle(int id);
        void AddTripVehicle(TripVehicle tripVehicle);
    }
}
