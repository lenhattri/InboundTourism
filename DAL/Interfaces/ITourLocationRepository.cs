using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{

    public interface ITourLocationRepository
    {
        IEnumerable<TourLocation> GetAll();

        TourLocation GetById(int TourID, int LocationID);

        void Delete(int TourID, int LocationID);

        void Update(TourLocation TourLocation);
    }
}
