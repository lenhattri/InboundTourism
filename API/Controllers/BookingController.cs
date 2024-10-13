using BLL.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    // Đặt route CRUD cho các API liên quan đến Booking
    [Route(ApiPath)]
    [ApiController]
    public class BookingController : ControllerBase
    {
        // Định nghĩa đường dẫn API với phiên bản v1 và controller hiện tại (Booking)
        private const string ApiPath = "api/v1/[controller]";
        private readonly IBookingService _bookingService;

        // Constructor nhận vào IBookingService để sử dụng các dịch vụ liên quan đến Booking
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET: api/v1/booking
        // Lấy danh sách tất cả các đơn đặt chỗ (Booking)
        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetBookings()
        {
            var bookings = _bookingService.GetBookings(); // Lấy dữ liệu danh sách Booking từ service
            return Ok(bookings); // Trả về danh sách các đơn đặt chỗ dưới dạng HTTP 200 (OK)
        }

        // GET: api/v1/booking/{id}
        // Lấy thông tin chi tiết của 1 đơn đặt chỗ dựa trên ID
        [HttpGet("{id}")]
        public ActionResult<Booking> GetBooking(int id)
        {
            var booking = _bookingService.GetBooking(id); // Lấy thông tin Booking theo ID

            // Kiểm tra nếu không tìm thấy Booking, trả về mã 404 (NotFound)
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking); // Trả về thông tin đơn đặt chỗ tìm thấy dưới dạng HTTP 200 (OK)
        }

        // POST: api/v1/booking
        // Thêm một đơn đặt chỗ mới
        [HttpPost]
        public ActionResult AddBooking(Booking booking)
        {
            _bookingService.AddBooking(booking); // Thực hiện thêm đơn đặt chỗ qua service
            return Ok(); // Trả về HTTP 200 (OK) nếu thêm thành công
        }

        // PUT: api/v1/booking/{id}
        // Cập nhật thông tin của một đơn đặt chỗ dựa trên ID
        [HttpPut("{id}")]
        public ActionResult UpdateBooking(int id, Booking booking)
        {
            // Kiểm tra nếu ID trong URL không khớp với ID của booking
            if (id != booking.BookingID)
            {
                return BadRequest(); // Trả về mã 400 (BadRequest) nếu không khớp
            }

            _bookingService.UpdateBooking(booking); // Thực hiện cập nhật đơn đặt chỗ qua service
            return NoContent(); // Trả về HTTP 204 (NoContent) khi cập nhật thành công
        }

        // DELETE: api/v1/booking/{id}
        // Xóa một đơn đặt chỗ dựa trên ID
        [HttpDelete("{id}")]
        public ActionResult DeleteBooking(int id)
        {
            _bookingService.DeleteBooking(id); // Thực hiện xóa đơn đặt chỗ qua service
            return NoContent(); // Trả về HTTP 204 (NoContent) khi xóa thành công
        }
    }
}
