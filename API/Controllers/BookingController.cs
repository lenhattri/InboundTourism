using BLL.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public ActionResult<Booking> GetBookingById(Guid id)
        {
            var booking = _bookingService.GetBookingById(id);

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

    
        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<Booking>> FindBookingsByUserId(Guid userId)
        {
            var bookings = _bookingService.FindBookingsByUserId(userId);

            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(bookings);
        }

       
        [HttpGet("trip/{tripId}")]
        public ActionResult<IEnumerable<Booking>> FindBookingsByTripId(Guid tripId)
        {
            var bookings = _bookingService.FindBookingsByTripId(tripId);

            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(bookings);
        }

        [HttpGet("date")]
        public ActionResult<IEnumerable<Booking>> FindBookings([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var bookings = _bookingService.FindBookings(startDate, endDate);

            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(bookings);
        }
    }
}
