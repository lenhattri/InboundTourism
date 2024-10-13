using BLL.Interfaces;
using Core.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
    public class TourLocationService : ITourLocationService
    {
        private readonly ITourLocationRepository _tourLocationRepository;

        public TourLocationService(ITourLocationRepository tourLocationRepository)
        {
            _tourLocationRepository = tourLocationRepository;
        }

        public IEnumerable<TourLocation> GetTourLocations()
        {
            return _tourLocationRepository.GetAll();
        }

        public TourLocation GetTourLocation(Guid TourID, Guid LocationID)
        {
            return _tourLocationRepository.GetById(TourID, LocationID);
        }

        public void UpdateTourLocation(TourLocation tourLocation)
        {
            _tourLocationRepository.Update(tourLocation);
        }

        public void DeleteTourLocation(Guid TourID, Guid LocationID)
        {
            _tourLocationRepository.Delete(TourID,LocationID);
        }

        public void AddTourLocation(TourLocation tourLocation)
        {
            _tourLocationRepository.Add(tourLocation);
        }
    }
}