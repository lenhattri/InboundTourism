using Core.Entities;

namespace BLL.Interfaces
{
    public interface ILocationService
    {
        IEnumerable<Location> GetLocations();
        Location GetLocation(int id);
        void UpdateLocation(Location location);
        void DeleteLocation(int id);
        void AddLocation(Location location);
    }
}
