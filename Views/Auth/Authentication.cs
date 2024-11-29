using System.Text;
using Base.Config;
using Base.DTO;
using Base.Utils.Fetch;
using Base.Utils.Hash;
using Core.Entities;
using Core.Enums;

namespace Views.Auth
{
    public class Authentication
    {
        public static async Task<(bool IsSuccess, Role UserRole)> SignIn(string username, string password)
        {
            var loginRequest = new
            {
                Email = username,
                Password = HashPassword.Hash(password)
            };

            try
            {
                var response = await FetchService.Instance.PostAsync<YourUserDto>($"{GlobalConfig.BASE_URL}/auth/login", loginRequest);

                if (response.Success)
                {
                    var userData = response.Data;
                    return (true, userData.Role);
                }
                else
                {
                    Console.WriteLine($"Đăng nhập thất bại: {response.ErrorMessage}");
                    return (false, Role.None);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đăng nhập: " + ex.Message);
                return (false, Role.None);
            }
        }

        public static async Task SignUp(User user)
        {
            var registerRequest = new
            {
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Password = user.Password,
                Address = user.Address,
                Role = user.Role,
            };

            try
            {
                var response = await FetchService.Instance.PostAsync<string>($"{GlobalConfig.BASE_URL}/auth/register", registerRequest);

                if (response.Success)
                {
                    Console.WriteLine("Đăng ký thành công: " + response.Data);
                }
                else
                {
                    Console.WriteLine($"Đăng ký thất bại: {response.ErrorMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đăng ký: " + ex.Message);
            }
        }
    }

    public class YourUserDto
    {
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
