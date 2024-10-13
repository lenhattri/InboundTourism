using BLL.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    // Đặt route CRUD cho các API liên quan đến Tour
    [Route(ApiPath)]
    [ApiController]
    public class TourController : ControllerBase
    {
        // Định nghĩa đường dẫn API với phiên bản v1 và controller hiện tại (Tour)
        private const string ApiPath = "api/v1/[controller]";
        private readonly ITourService _tourService;

        // Constructor nhận vào ITourService để sử dụng các dịch vụ liên quan đến Tour
        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }

        // GET: api/v1/tour
        // Lấy danh sách tất cả các tour
        [HttpGet]
        public ActionResult<IEnumerable<Tour>> GetTours()
        {
            var tours = _tourService.GetTours(); // Lấy dữ liệu danh sách Tour từ service
            return Ok(tours); // Trả về danh sách các tour dưới dạng HTTP 200 (OK)
        }

        // GET: api/v1/tour/{id}
        // Lấy thông tin chi tiết của 1 tour dựa trên ID
        [HttpGet("{id}")]
        public ActionResult<Tour> GetTour(int id)
        {
            var tour = _tourService.GetTour(id); // Lấy thông tin Tour theo ID

            // Kiểm tra nếu không tìm thấy Tour, trả về mã 404 (NotFound)
            if (tour == null)
            {
                return NotFound();
            }

            return Ok(tour); // Trả về thông tin tour tìm thấy dưới dạng HTTP 200 (OK)
        }

        // POST: api/v1/tour
        // Thêm một tour mới
        [HttpPost]
        public ActionResult AddTour(Tour tour)
        {
            _tourService.AddTour(tour); // Thực hiện thêm tour qua service
            return Ok(); // Trả về HTTP 200 (OK) nếu thêm thành công
        }

        // PUT: api/v1/tour/{id}
        // Cập nhật thông tin của một tour dựa trên ID
        [HttpPut("{id}")]
        public ActionResult UpdateTour(int id, Tour tour)
        {
            // Kiểm tra nếu ID trong URL không khớp với ID của tour
            if (id != tour.TourID)
            {
                return BadRequest(); // Trả về mã 400 (BadRequest) nếu không khớp
            }

            _tourService.UpdateTour(tour); // Thực hiện cập nhật tour qua service
            return NoContent(); // Trả về HTTP 204 (NoContent) khi cập nhật thành công
        }

        // DELETE: api/v1/tour/{id}
        // Xóa một tour dựa trên ID
        [HttpDelete("{id}")]
        public ActionResult DeleteTour(int id)
        {
            _tourService.DeleteTour(id); // Thực hiện xóa tour qua service
            return NoContent(); // Trả về HTTP 204 (NoContent) khi xóa thành công
        }
    }
}
