using Core.Entities;


namespace DAL.Interfaces
{

    public interface ITourLocationRepository
    {
        IEnumerable<TourLocation> GetAll();

        TourLocation GetById(Guid TourID, Guid LocationID);
        public void Add(TourLocation tourLocation);
        void Delete(Guid TourID, Guid LocationID);

        void Update(TourLocation TourLocation);
    }
}
