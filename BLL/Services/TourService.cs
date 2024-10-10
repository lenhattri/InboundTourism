using BLL.Interfaces;
using Core.Entities;

using DAL.Interfaces;
namespace BLL.Services
{
    public class TourService : ITourService
    {
        
        private readonly IGenericRepository<Tour> _tourRepository;
        private readonly IGenericRepository<Booking> _BookingRepository;
        public TourService(IGenericRepository<Tour> tourRepository) {
              _tourRepository = tourRepository;
        }
        public IEnumerable<Tour> GetTours()
        {
            return _tourRepository.GetAll();
        }
        public Tour GetTour(int id)
        {
            return _tourRepository.GetById(id);
        }

        public void UpdateTour(Tour tour)
        {
            _tourRepository.Update(tour);
        }
        public void DeleteTour(int id)
        {
            _tourRepository.Delete(id);
        }
        public void AddTour(Tour tour)
        {
            _tourRepository.Add(tour);

        }


    }
}
