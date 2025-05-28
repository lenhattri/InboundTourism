using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BLL.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Hosting; 
using Microsoft.AspNetCore.Http;
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
            _env = env; // <- Gán vào field
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
            // 1. Check tồn tại location
            var location = _locationService.GetLocation(id);
            if (location == null)
                return NotFound();

            // 2. Lưu file lên server
            var uploadsFolder = Path.Combine(_env.WebRootPath, "images", "locations");
            Directory.CreateDirectory(uploadsFolder);

            var fileName = $"{id}{Path.GetExtension(imageFile.FileName)}";
            var filePath = Path.Combine(uploadsFolder, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
                await imageFile.CopyToAsync(stream);

            // 3. Cập nhật ImageUrl
            location.ImageUrl = $"/images/locations/{fileName}";
            _locationService.UpdateLocation(location);

            return Ok(new { imageUrl = location.ImageUrl });
        }
    }
}
