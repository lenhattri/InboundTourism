using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITripService
    {
        public IEnumerable<Trip> GetTrips();
        public Trip GetTrip(int id);

        public void UpdateTrip(Trip Trip);
        public void DeleteTrip(int id);
        public void AddTrip(Trip Trip);

    }
}
