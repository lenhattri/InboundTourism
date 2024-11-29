using BLL.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route(ApiPath)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private const string ApiPath = "api/v1/[controller]";
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(Guid id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {

            try
            {
                _userService.AddUser(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(Guid id, User user)
        {
            if (id != user.UserID)
            {
                return BadRequest("ID không khớp với dữ liệu người dùng.");
            }
            
            try
            {
                _userService.UpdateUser(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                
                return BadRequest( ex.Message );
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(Guid id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
