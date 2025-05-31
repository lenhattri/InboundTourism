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
        private readonly IWebHostEnvironment _env;    

        // Inject IWebHostEnvironment vào constructor
        public LocationController(
            ILocationService locationService,
            IWebHostEnvironment env)
        {
            _locationService = locationService;
            _env = env; 
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
            if (location == null) return NotFound();
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

        // ---------------- Upload Image Action ----------------
        [HttpPost("{id:guid}/upload-image")]
        public async Task<IActionResult> UploadImage(
    Guid id,
    IFormFile imageFile)
        {
            // 1. Lấy location
            var location = _locationService.GetLocation(id);
            if (location == null)
                return NotFound();

            // 2. Thư mục lưu ảnh
            var uploadsFolder = Path.Combine(_env.WebRootPath, "images", "locations");
            Directory.CreateDirectory(uploadsFolder);

            // 3. Xoá file cũ
            if (!string.IsNullOrEmpty(location.ImageUrl))
            {
                var oldFileName = Path.GetFileName(location.ImageUrl);
                var oldFilePath = Path.Combine(uploadsFolder, oldFileName);
                if (System.IO.File.Exists(oldFilePath))
                    System.IO.File.Delete(oldFilePath);
            }

            // 4. Tạo tên file mới 
            var newFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
            var newFilePath = Path.Combine(uploadsFolder, newFileName);

            // 5. Lưu file mới
            using (var stream = new FileStream(newFilePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            // 6. Cập nhật ImageUrl và lưu DB
            location.ImageUrl = $"/images/locations/{newFileName}";
            _locationService.UpdateLocation(location);

            return Ok(new { imageUrl = location.ImageUrl });
        }
    }
}
