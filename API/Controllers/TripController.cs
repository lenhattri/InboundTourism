using BLL.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    // Đặt route cho các API liên quan đến Trip
    [Route(ApiPath)]
    [ApiController]
    public class TripController : ControllerBase
    {
        // Định nghĩa đường dẫn API với phiên bản v1 và controller Trip
        private const string ApiPath = "api/v1/[controller]";
        private readonly ITripService _tripService;

        // Constructor nhận vào ITripService để sử dụng các dịch vụ liên quan đến Trip
        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }

        // GET: api/v1/trip
        // Lấy danh sách tất cả các chuyến đi (Trip)
        [HttpGet]
        public ActionResult<IEnumerable<Trip>> GetTrips()
        {
            var trips = _tripService.GetTrips(); // Lấy dữ liệu danh sách Trip từ service
            return Ok(trips); // Trả về danh sách các chuyến đi dưới dạng HTTP 200 (OK)
        }

        // GET: api/v1/trip/{id}
        // Lấy thông tin chi tiết của 1 chuyến đi dựa trên ID
        [HttpGet("{id}")]
        public ActionResult<Trip> GetTrip(int id)
        {
            var trip = _tripService.GetTrip(id); // Lấy thông tin Trip theo ID

            // Kiểm tra nếu không tìm thấy Trip, trả về mã 404 (NotFound)
            if (trip == null)
            {
                return NotFound();
            }

            return Ok(trip); // Trả về thông tin chuyến đi tìm thấy dưới dạng HTTP 200 (OK)
        }

        // POST: api/v1/trip
        // Thêm một chuyến đi mới
        [HttpPost]
        public ActionResult AddTrip(Trip trip)
        {
            _tripService.AddTrip(trip); // Thực hiện thêm chuyến đi qua service
            return Ok(); // Trả về HTTP 200 (OK) nếu thêm thành công
        }

        // PUT: api/v1/trip/{id}
        // Cập nhật thông tin của một chuyến đi dựa trên ID
        [HttpPut("{id}")]
        public ActionResult UpdateTrip(int id, Trip trip)
        {
            // Kiểm tra nếu ID trong URL không khớp với ID của trip
            if (id != trip.TripID)
            {
                return BadRequest(); // Trả về mã 400 (BadRequest) nếu không khớp
            }

            _tripService.UpdateTrip(trip); // Thực hiện cập nhật chuyến đi qua service
            return NoContent(); // Trả về HTTP 204 (NoContent) khi cập nhật thành công
        }

        // DELETE: api/v1/trip/{id}
        // Xóa một chuyến đi dựa trên ID
        [HttpDelete("{id}")]
        public ActionResult DeleteTrip(int id)
        {
            _tripService.DeleteTrip(id); // Thực hiện xóa chuyến đi qua service
            return NoContent(); // Trả về HTTP 204 (NoContent) khi xóa thành công
        }
    }
}
