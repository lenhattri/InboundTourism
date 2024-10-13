using Core.Entities;

namespace BLL.Interfaces
{
    public interface ITourLocationService
    {
        IEnumerable<TourLocation> GetTourLocations();
        TourLocation GetTourLocation(Guid id);
        void UpdateTourLocation(TourLocation tourLocation);
        void DeleteTourLocation(Guid id);
        void AddTourLocation(TourLocation tourLocation);
    }
}
