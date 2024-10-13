using Core.Entities;


namespace BLL.Interfaces
{
    public interface ITourService
    {
        public IEnumerable<Tour> GetTours();
        public Tour GetTour(Guid id);

        public void UpdateTour(Tour tour);
        public void DeleteTour(Guid id);
        public void AddTour(Tour tour);
           
    }
}
