using API.DTO;
using Base.Utils.Hash;
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
            try
            {
                var user = _authService.Login(req.Email, req.Password);

                if (user == null)
                {
                    return Unauthorized(new { message = "Email hoặc mật khẩu không chính xác.", status = "0" });
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("register")]
        public ActionResult Register(RegisterRequest req)
        {
            try
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
                    return Conflict("Email đã được sử dụng." );
                }

                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return BadRequest( ex.Message);
            }
        }
    }
}
