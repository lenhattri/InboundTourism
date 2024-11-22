using BLL.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route(ApiPath)]
    [ApiController]
    public class TourLocationController : ControllerBase
    {
        private const string ApiPath = "api/v1/[controller]";
        private readonly ITourLocationService _tourLocationService;

        public TourLocationController(ITourLocationService tourLocationService)
        {
            _tourLocationService = tourLocationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TourLocation>> GetTourLocations()
        {
            var tourLocations = _tourLocationService.GetAllTourLocations();
            return Ok(tourLocations);
        }

        [HttpGet("{tourId}/{locationId}")]
        public ActionResult<TourLocation> GetTourLocation(Guid tourId, Guid locationId)
        {
            var tourLocation = _tourLocationService.GetTourLocation(tourId, locationId);

            if (tourLocation == null)
            {
                return NotFound();
            }

            return Ok(tourLocation);
        }

        [HttpPost]
        public ActionResult AddTourLocation(TourLocation tourLocation)
        {
            _tourLocationService.AddTourLocation(tourLocation);
            return Ok();
        }

        [HttpPut("{tourId}/{locationId}")]
        public ActionResult UpdateTourLocation(Guid tourId, Guid locationId, TourLocation tourLocation)
        {
            if (tourId != tourLocation.TourID || locationId != tourLocation.LocationID)
            {
                return BadRequest();
            }

            _tourLocationService.UpdateTourLocation(tourLocation);
            return NoContent();
        }

        [HttpDelete("{tourId}/{locationId}")]
        public ActionResult DeleteTourLocation(Guid tourId, Guid locationId)
        {
            _tourLocationService.DeleteTourLocation(tourId, locationId);
            return NoContent();
        }

        // New Endpoint: Find by TourId
        [HttpGet("tour/{tourId}")]
        public ActionResult<IEnumerable<TourLocation>> FindByTourId(Guid tourId)
        {
            var tourLocations = _tourLocationService.FindByTourId(tourId);

            if (tourLocations == null)
            {
                return NotFound();
            }

            return Ok(tourLocations);
        }

        // New Endpoint: Find by LocationId
        [HttpGet("location/{locationId}")]
        public ActionResult<IEnumerable<TourLocation>> FindByLocationId(Guid locationId)
        {
            var tourLocations = _tourLocationService.FindByLocationId(locationId);

            if (tourLocations == null)
            {
                return NotFound();
            }

            return Ok(tourLocations);
        }
    }
}
