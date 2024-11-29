using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Base.DTO;
namespace Base.Utils.Fetch
{
    public class FetchService
    {
        private static readonly Lazy<FetchService> _instance = new Lazy<FetchService>(() => new FetchService());
        private readonly HttpClient _httpClient = new HttpClient();

        private FetchService() { }

        public static FetchService Instance => _instance.Value;


        // GET Method
        public async Task<ApiResponse<T>> GetAsync<T>(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    return new ApiResponse<T>
                    {
                        Success = true,
                        Data = JsonConvert.DeserializeObject<T>(jsonData)
                    };
                }
                else
                {
                    return new ApiResponse<T>
                    {
                        Success = false,
                        ErrorMessage = $"{response.StatusCode}, {await response.Content.ReadAsStringAsync()}"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>
                {
                    Success = false,
                    ErrorMessage = $"{ex.Message}"
                };
            }
        }

        // POST Method
        public async Task<ApiResponse<T>> PostAsync<T>(string endpoint, object data)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(data);

                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(endpoint, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    return new ApiResponse<T>
                    {
                        Success = true,
                        Data = JsonConvert.DeserializeObject<T>(jsonData)
                    };
                }
                else
                {
                    return new ApiResponse<T>
                    {
                        Success = false,
                        ErrorMessage = $"{response.StatusCode}, {await response.Content.ReadAsStringAsync()}"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>
                {
                    Success = false,
                    ErrorMessage = $"{ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<T>> PutAsync<T>(string endpoint, object data)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(data);

                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsync(endpoint, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    return new ApiResponse<T>
                    {
                        Success = true,
                        Data = JsonConvert.DeserializeObject<T>(jsonData)
                    };
                }
                else
                {
                    return new ApiResponse<T>
                    {
                        Success = false,
                        ErrorMessage = $"{response.StatusCode}, {await response.Content.ReadAsStringAsync()}"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>
                {
                    Success = false,
                    ErrorMessage = $"{ex.Message}"
                };
            }
        }

        // DELETE Method
        public async Task<ApiResponse<bool>> DeleteAsync(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    return new ApiResponse<bool>
                    {
                        Success = true,
                        Data = true
                    };
                }
                else
                {
                    return new ApiResponse<bool>
                    {
                        Success = false,
                        ErrorMessage = $"{response.StatusCode}, {await response.Content.ReadAsStringAsync()}"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    ErrorMessage = $"{ex.Message}"
                };
            }
        }
    }
}
