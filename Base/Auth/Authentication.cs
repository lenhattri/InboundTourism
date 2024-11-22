using System.Text;
using System.Text.Json;
using Base.Config;
using Core.Entities;
using Core.Enums;

namespace Base.Auth
{
    public class Authentication
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<(bool IsSuccess, Role UserRole)> SignIn(string username, string password)
        {
            var loginRequest = new
            {
                Email = username,
                Password = password
            };

            var content = new StringContent(
                JsonSerializer.Serialize(loginRequest),
                Encoding.UTF8,
                "application/json"
            );

            try
            {
                var response = await _httpClient.PostAsync($"{GlobalConfig.BASE_URL}/auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var userData = JsonSerializer.Deserialize<YourUserDto>(responseContent);

                    
                    return (true, userData.Role);
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Đăng nhập thất bại: {response.StatusCode} - {errorMessage}");
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

            var content = new StringContent(
                JsonSerializer.Serialize(registerRequest),
                Encoding.UTF8,
                "application/json"
            );

            try
            {
                var response = await _httpClient.PostAsync($"{GlobalConfig.BASE_URL}/auth/register", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Đăng ký thành công: " + responseContent);
                    
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Đăng ký thất bại: {response.StatusCode}, {errorMessage}");
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
