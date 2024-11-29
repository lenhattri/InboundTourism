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
            try
            {
                var bookings = _bookingService.GetBookings();
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message );
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Booking> GetBookingById(Guid id)
        {
            try
            {
                var booking = _bookingService.GetBookingById(id);

                if (booking == null)
                {
                    return NotFound("Không tìm thấy booking với ID cung cấp.");
                }

                return Ok(booking);
            }
            catch (Exception ex)
            {
                return BadRequest( ex.Message );
            }
        }

        [HttpPost]
        public ActionResult AddBooking(Booking booking)
        {
            try
            {
                _bookingService.AddBooking(booking);
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBooking(Guid id, Booking booking)
        {
            try
            {
                if (id != booking.BookingID)
                {
                    return BadRequest("ID không khớp với thông tin booking.");
                }

                _bookingService.UpdateBooking(booking);
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBooking(Guid id)
        {
            try
            {
                _bookingService.DeleteBooking(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message );
            }
        }

        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<Booking>> FindBookingsByUserId(Guid userId)
        {
            try
            {
                var bookings = _bookingService.FindBookingsByUserId(userId);

                if (bookings == null || !bookings.Any())
                {
                    return NotFound("Không tìm thấy booking nào của người dùng này." );
                }

                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message );
            }
        }

        [HttpGet("trip/{tripId}")]
        public ActionResult<IEnumerable<Booking>> FindBookingsByTripId(Guid tripId)
        {
            try
            {
                var bookings = _bookingService.FindBookingsByTripId(tripId);

                if (bookings == null || !bookings.Any())
                {
                    return NotFound(new { Message = "Không tìm thấy booking nào cho chuyến đi này." });
                }

                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest( ex.Message );
            }
        }

        [HttpGet("date")]
        public ActionResult<IEnumerable<Booking>> FindBookings([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            try
            {
                var bookings = _bookingService.FindBookings(startDate, endDate);

                if (bookings == null || !bookings.Any())
                {
                    return NotFound(new { Message = "Không tìm thấy booking nào trong khoảng thời gian được cung cấp." });
                }

                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
