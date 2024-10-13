using BLL.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    // Đặt route CRUD cho các API liên quan đến User
    [Route(ApiPath)]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Định nghĩa đường dẫn API với phiên bản v1 và controller hiện tại (User)
        private const string ApiPath = "api/v1/[controller]";
        private readonly IUserService _userService;

        // Constructor nhận vào IUserService để sử dụng các dịch vụ liên quan đến User
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/v1/user
        // Lấy danh sách tất cả các user
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _userService.GetUsers(); // Lấy dữ liệu users từ service
            return Ok(users); // Trả về danh sách users dưới dạng HTTP 200 (OK)
        }

        // GET: api/v1/user/{id}
        // Lấy thông tin chi tiết của 1 user dựa trên ID
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userService.GetUser(id); // Lấy thông tin user theo ID

            // Kiểm tra nếu không tìm thấy user, trả về mã 404 (NotFound)
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user); // Trả về user tìm thấy dưới dạng HTTP 200 (OK)
        }

        // POST: api/v1/user
        // Thêm một user mới
        [HttpPost]
        public ActionResult AddUser(User user)
        {
            _userService.AddUser(user); // Thực hiện thêm user qua service
            return Ok(); // Trả về HTTP 200 (OK) nếu thêm thành công
        }

        // PUT: api/v1/user/{id}
        // Cập nhật thông tin của một user dựa trên ID
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, User user)
        {
            // Kiểm tra nếu ID trong URL không khớp với ID của user
            if (id != user.UserID)
            {
                return BadRequest(); // Trả về mã 400 (BadRequest) nếu không khớp
            }

            _userService.UpdateUser(user); // Thực hiện cập nhật user qua service
            return NoContent(); // Trả về HTTP 204 (NoContent) khi cập nhật thành công
        }

        // DELETE: api/v1/user/{id}
        // Xóa một user dựa trên ID
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id); // Thực hiện xóa user qua service
            return NoContent(); // Trả về HTTP 204 (NoContent) khi xóa thành công
        }
    }
}
