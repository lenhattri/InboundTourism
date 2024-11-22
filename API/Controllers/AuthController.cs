using API.DTO;
using BLL.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route(ApiPath)]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private const string ApiPath = "api/v1/[controller]";
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(LoginRequest req)
        {
            var user = _authService.Login(req.Email, req.Password);
            if (user == null)
            {
                return Unauthorized(new { message = "Email hoặc mật khẩu không chính xác." , status = "0" });
            }

            return Ok(new
            {
                message = "Đăng nhập thành công.",
                
                user = new
                {
                    user.UserID,
                    user.Email,
                    user.FullName,
                    user.Role
                }
            });
        }

        [HttpPost("register")]
        public ActionResult Register(RegisterRequest req)
        {
            var newUser = new User
            {
                FullName = req.FullName,
                PhoneNumber = req.PhoneNumber,
                Email = req.Email,
                Password = req.Password,
                Address = req.Address,

            };

            if (!_authService.Register(newUser))
            {
                return Conflict(new { message = "Email đã được sử dụng." });
            }

            return Ok(new
            {
                message = "Đăng ký thành công.",
                user = new
                {
                    newUser.UserID,
                    newUser.Email,
                    newUser.FullName,
                    newUser.Role
                }
            });
        }
    }
}
