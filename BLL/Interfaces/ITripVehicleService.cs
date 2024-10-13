using Core.Entities;

namespace BLL.Interfaces
{
    public interface ITripVehicleService
    {
        IEnumerable<TripVehicle> GetTripVehicles();
        TripVehicle GetTripVehicle(Guid id);
        void UpdateTripVehicle(TripVehicle tripVehicle);
        void DeleteTripVehicle(Guid id);
        void AddTripVehicle(TripVehicle tripVehicle);
    }
}
