using Core.Entities;


namespace BLL.Interfaces
{
    public interface ITripService
    {
        public IEnumerable<Trip> GetTrips();
        public Trip GetTrip(Guid id);

        public void UpdateTrip(Trip Trip);
        public void DeleteTrip(Guid id);
        public void AddTrip(Trip Trip);

    }
}
