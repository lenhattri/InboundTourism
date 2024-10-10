using BLL.Interfaces;
using Core.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class LocationService : ILocationService
    {
        private readonly IGenericRepository<Location> _locationRepository;

        public LocationService(IGenericRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public IEnumerable<Location> GetLocations()
        {
            return _locationRepository.GetAll();
        }

        public Location GetLocation(int id)
        {
            return _locationRepository.GetById(id);
        }

        public void UpdateLocation(Location location)
        {
            _locationRepository.Update(location);
        }

        public void DeleteLocation(int id)
        {
            _locationRepository.Delete(id);
        }

        public void AddLocation(Location location)
        {
            _locationRepository.Add(location);
        }
    }
}
