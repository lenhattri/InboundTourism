using Core.Entities;


namespace BLL.Interfaces
{
    public interface ITourService
    {
        public IEnumerable<Tour> GetTours();
        public Tour GetTour(int id);

        public void UpdateTour(Tour tour);
        public void DeleteTour(int id);
        public void AddTour(Tour tour);
           
    }
}
