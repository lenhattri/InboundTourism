using BLL.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route(ApiPath)]
    [ApiController]
    public class TripController : ControllerBase
    {
        private const string ApiPath = "api/v1/[controller]";
        private readonly ITripService _tripService;

        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Trip>> GetTrips()
        {
            var trips = _tripService.GetTrips();
            return Ok(trips);
        }

        [HttpGet("{id}")]
        public ActionResult<Trip> GetTrip(Guid id)
        {
            var trip = _tripService.GetTrip(id);

            if (trip == null)
            {
                return NotFound();
            }

            return Ok(trip);
        }

        [HttpPost]
        public ActionResult AddTrip(Trip trip)
        {
            _tripService.AddTrip(trip);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTrip(Guid id, Trip trip)
        {
            if (id != trip.TripID)
            {
                return BadRequest();
            }

            _tripService.UpdateTrip(trip);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTrip(Guid id)
        {
            _tripService.DeleteTrip(id);
            return NoContent();
        }
    }
}
