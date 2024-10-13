using BLL.Interfaces;
using Core.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TourLocationService : ITourLocationService
    {
        private readonly IGenericRepository<TourLocation> _tourLocationRepository;

        public TourLocationService(IGenericRepository<TourLocation> tourLocationRepository)
        {
            _tourLocationRepository = tourLocationRepository;
        }

        public IEnumerable<TourLocation> GetTourLocations()
        {
            return _tourLocationRepository.GetAll();
        }

        public TourLocation GetTourLocation(Guid id)
        {
            return _tourLocationRepository.GetById(id);
        }

        public void UpdateTourLocation(TourLocation tourLocation)
        {
            _tourLocationRepository.Update(tourLocation);
        }

        public void DeleteTourLocation(Guid id)
        {
            _tourLocationRepository.Delete(id);
        }

        public void AddTourLocation(TourLocation tourLocation)
        {
            _tourLocationRepository.Add(tourLocation);
        }
    }
}