using Core.Entities;

namespace BLL.Interfaces
{
    public interface ITourLocationService
    {
        IEnumerable<TourLocation> GetTourLocations();
        TourLocation GetTourLocation(int id);
        void UpdateTourLocation(TourLocation tourLocation);
        void DeleteTourLocation(int id);
        void AddTourLocation(TourLocation tourLocation);
    }
}
