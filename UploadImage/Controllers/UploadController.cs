using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUploadApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly string _uploadFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        private readonly string[] _allowedFileExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

        public UploadController()
        {
            // Tạo thư mục upload nếu chưa tồn tại
            if (!Directory.Exists(_uploadFolderPath))
            {
                Directory.CreateDirectory(_uploadFolderPath);
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            // Kiểm tra xem file có tồn tại hay không
            if (file == null || file.Length == 0)
            {
                return BadRequest("File không hợp lệ.");
            }

            // Kiểm tra định dạng file
            string fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!_allowedFileExtensions.Contains(fileExtension))
            {
                return BadRequest("Định dạng file không được phép. Chỉ chấp nhận file ảnh (.jpg, .jpeg, .png, .gif).");
            }

            try
            {
                string originalFileName = Path.GetFileNameWithoutExtension(file.FileName);
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string newFileName = $"{originalFileName}_{timestamp}{fileExtension}";
                string filePath = Path.Combine(_uploadFolderPath, newFileName);

 
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }


                string fileUrl = $"{Request.Scheme}://{Request.Host}/Uploads/{newFileName}";

                return Ok(new
                {
                    Message = "Upload thành công.",
                    status = "1",
                    FileUrl = fileUrl
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "Đã xảy ra lỗi khi upload file.",
                    status="0",
                    Error = ex.Message
                });
            }
        }

        [HttpGet("list")]
        public IActionResult ListUploadedFiles()
        {
        
            var fileList = Directory.GetFiles(_uploadFolderPath)
                .Select(file => new
                {
                    FileName = Path.GetFileName(file),
                    FileUrl = $"{Request.Scheme}://{Request.Host}/Uploads/{Path.GetFileName(file)}"
                });

            return Ok(fileList);
        }
    }
}
