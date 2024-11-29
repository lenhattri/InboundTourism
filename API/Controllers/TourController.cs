using BLL.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using API.DTO;
namespace API.Controllers
{
    [Route(ApiPath)]
    [ApiController]
    public class TourController : ControllerBase
    {
        private const string ApiPath = "api/v1/[controller]";
        private readonly ITourService _tourService;

        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tour>> GetTours()
        {
            var tours = _tourService.GetTours();
            return Ok(tours);
        }

        [HttpGet("{id}")]
        public ActionResult<Tour> GetTour(Guid id)
        {
            var tour = _tourService.GetTour(id);

            if (tour == null)
            {
                return NotFound();
            }

            return Ok(tour);
        }

        [HttpPost]
        public ActionResult AddTour([FromBody] TourCreateRequest request)
        {
            var tour = new Tour
            {
                TourID = Guid.NewGuid(),
                TourName = request.TourName,
                Description = request.Description
            };

            _tourService.AddTour(tour, request.LocationIds);
            return Ok(tour);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTour(Guid id, Tour tour)
        {
            if (id != tour.TourID)
            {
                return BadRequest();
            }

            _tourService.UpdateTour(tour);
            return Ok(tour);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTour(Guid id)
        {
            _tourService.DeleteTour(id);
            return NoContent();
        }
    }
}
