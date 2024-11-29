using Base.Utils.Fetch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Base.Config;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Newtonsoft.Json.Linq;
using Base.Auth;
using Core.Entities;
namespace Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            Console.WriteLine(model.ToString());

            // Gửi yêu cầu tới API
            var response = await FetchService.Instance.PostAsync<JObject>(
                $"{GlobalConfig.BASE_URL}/auth/login", model);

            if (response.Success)
            {
                
                var user = response.Data;

                
                var email = user["email"]?.ToString();
                var fullName = user["fullName"]?.ToString();
                var userId = user["userID"]?.ToString();
                var roleValue = user["role"]?.ToObject<int>() ?? -1;

                
                var role = Enum.IsDefined(typeof(Core.Enums.Role), roleValue)
                    ? ((Core.Enums.Role)roleValue).ToString()
                    : Core.Enums.Role.None.ToString(); 

                
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, email),
                    new Claim("FullName", fullName ?? string.Empty),
                    new Claim("UserID", userId),
                    new Claim(ClaimTypes.Role, role) 
                };

            
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = response.ErrorMessage ?? "Email hoặc mật khẩu không chính xác.";
                return View(model);
            }
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); 
            }

            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Mật khẩu và xác nhận mật khẩu không khớp.");
                return View(model);
            }

          
            var user = new User
            {
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Password = model.Password,
                Address = model.Address
            };

            await Authentication.SignUp(user);

            ViewBag.Message = "Đăng ký thành công! Vui lòng đăng nhập.";
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }

    }
}

