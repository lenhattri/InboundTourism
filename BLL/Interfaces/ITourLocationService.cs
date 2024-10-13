using Core.Entities;

namespace BLL.Interfaces
{
    public interface ITourLocationService
    {
        IEnumerable<TourLocation> GetTourLocations();
        TourLocation GetTourLocation(Guid TourID, Guid LocationID);
        void UpdateTourLocation(TourLocation tourLocation);
        void DeleteTourLocation(Guid TourID, Guid LocationID);
        void AddTourLocation(TourLocation tourLocation);
    }
}
