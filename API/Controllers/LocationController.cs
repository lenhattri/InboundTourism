using BLL.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route(ApiPath)]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private const string ApiPath = "api/v1/[controller]";
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Location>> GetLocations()
        {
            var locations = _locationService.GetLocations();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public ActionResult<Location> GetLocation(Guid id)
        {
            var location = _locationService.GetLocation(id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        [HttpPost]
        public ActionResult AddLocation(Location location)
        {
            _locationService.AddLocation(location);
            return Ok(location);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateLocation(Guid id, Location location)
        {
            if (id != location.LocationID)
            {
                return BadRequest();
            }

            _locationService.UpdateLocation(location);
            return Ok(location);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteLocation(Guid id)
        {
            _locationService.DeleteLocation(id);
            return NoContent();
        }
    }
}
