using BLL.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    // Đặt route CRUD cho các API liên quan đến Location
    [Route(ApiPath)]
    [ApiController]
    public class LocationController : ControllerBase
    {
        // Định nghĩa đường dẫn API với phiên bản v1 và controller hiện tại (Location)
        private const string ApiPath = "api/v1/[controller]";
        private readonly ILocationService _locationService;

        // Constructor nhận vào ILocationService để sử dụng các dịch vụ liên quan đến Location
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        // GET: api/v1/location
        // Lấy danh sách tất cả các địa điểm (Location)
        [HttpGet]
        public ActionResult<IEnumerable<Location>> GetLocations()
        {
            var locations = _locationService.GetLocations(); // Lấy dữ liệu danh sách Location từ service
            return Ok(locations); // Trả về danh sách các địa điểm dưới dạng HTTP 200 (OK)
        }

        // GET: api/v1/location/{id}
        // Lấy thông tin chi tiết của 1 địa điểm dựa trên ID
        [HttpGet("{id}")]
        public ActionResult<Location> GetLocation(int id)
        {
            var location = _locationService.GetLocation(id); // Lấy thông tin Location theo ID

            // Kiểm tra nếu không tìm thấy Location, trả về mã 404 (NotFound)
            if (location == null)
            {
                return NotFound();
            }

            return Ok(location); // Trả về thông tin địa điểm tìm thấy dưới dạng HTTP 200 (OK)
        }

        // POST: api/v1/location
        // Thêm một địa điểm mới
        [HttpPost]
        public ActionResult AddLocation(Location location)
        {
            _locationService.AddLocation(location); // Thực hiện thêm địa điểm qua service
            return Ok(); // Trả về HTTP 200 (OK) nếu thêm thành công
        }

        // PUT: api/v1/location/{id}
        // Cập nhật thông tin của một địa điểm dựa trên ID
        [HttpPut("{id}")]
        public ActionResult UpdateLocation(int id, Location location)
        {
            // Kiểm tra nếu ID trong URL không khớp với ID của location
            if (id != location.LocationID)
            {
                return BadRequest(); // Trả về mã 400 (BadRequest) nếu không khớp
            }

            _locationService.UpdateLocation(location); // Thực hiện cập nhật địa điểm qua service
            return NoContent(); // Trả về HTTP 204 (NoContent) khi cập nhật thành công
        }

        // DELETE: api/v1/location/{id}
        // Xóa một địa điểm dựa trên ID
        [HttpDelete("{id}")]
        public ActionResult DeleteLocation(int id)
        {
            _locationService.DeleteLocation(id); // Thực hiện xóa địa điểm qua service
            return NoContent(); // Trả về HTTP 204 (NoContent) khi xóa thành công
        }
    }
}
