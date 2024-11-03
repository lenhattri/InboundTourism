using BLL.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route(ApiPath)]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private const string ApiPath = "api/v1/[controller]";
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetBookings()
        {
            var bookings = _bookingService.GetBookings();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public ActionResult<Booking> GetBooking(Guid id)
        {
            var booking = _bookingService.GetBooking(id);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpPost]
        public ActionResult AddBooking(Booking booking)
        {
            _bookingService.AddBooking(booking);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBooking(Guid id, Booking booking)
        {
            if (id != booking.BookingID)
            {
                return BadRequest();
            }

            _bookingService.UpdateBooking(booking);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBooking(Guid id)
        {
            _bookingService.DeleteBooking(id);
            return NoContent();
        }
    }
}
