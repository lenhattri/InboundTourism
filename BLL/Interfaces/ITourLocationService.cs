using Core.Entities;


namespace BLL.Interfaces
{
    public interface ITourLocationService
    {
        IEnumerable<TourLocation> GetAllTourLocations();
        TourLocation GetTourLocation(Guid tourId, Guid locationId);
        void AddTourLocation(TourLocation tourLocation);
        void UpdateTourLocation(TourLocation tourLocation);
        void DeleteTourLocation(Guid tourId, Guid locationId);
        IEnumerable<TourLocation> FindByTourId(Guid tourId);
        IEnumerable<TourLocation> FindByLocationId(Guid locationId);
    }
}

