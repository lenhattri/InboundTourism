using Core.Entities;

namespace BLL.Interfaces
{
    public interface ILocationService
    {
        IEnumerable<Location> GetLocations();
        Location GetLocation(Guid id);
        void UpdateLocation(Location location);
        void DeleteLocation(Guid id);
        void AddLocation(Location location);
    }
}
