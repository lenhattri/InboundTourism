using BLL.Interfaces;
using Core.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ITourLocationRepository _tourLocationRepository;

        public LocationService(ILocationRepository locationRepository, ITourLocationRepository tourLocationRepository)
        {
            _locationRepository = locationRepository;
            _tourLocationRepository = tourLocationRepository;
        }


        public IEnumerable<Location> GetLocations()
        {
            return _locationRepository.GetAll();
        }

        public Location GetLocation(Guid id)
        {
            return _locationRepository.GetById(id);
        }

        public void UpdateLocation(Location location)
        {
            _locationRepository.Update(location);
        }

        public void DeleteLocation(Guid id)
        {

            var existingTourLocations = _tourLocationRepository.FindByLocationId(id);
            foreach (var tourLocation in existingTourLocations)
            {
                _tourLocationRepository.Delete(tourLocation.TourID, tourLocation.LocationID);
            }
            _locationRepository.Delete(id);
        }

        public void AddLocation(Location location)
        {
            _locationRepository.Add(location);
        }
    }
}
