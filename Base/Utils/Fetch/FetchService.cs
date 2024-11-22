using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Base.Utils.Fetch
{
    public class FetchService
    {
        private static readonly Lazy<FetchService> _instance = new Lazy<FetchService>(() => new FetchService());
        private readonly HttpClient _httpClient = new HttpClient();

        private FetchService() { }

        public static FetchService Instance => _instance.Value;

        public async Task<T> GetAsync<T>(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonData);
                }
                else
                {
                    Console.WriteLine($"GET thất bại với mã trạng thái: {response.StatusCode}");
                    return default;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thực hiện GET: {ex.Message}");
                return default;
            }
        }

        public async Task<T> PostAsync<T>(string endpoint, object data)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(data);
                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(endpoint, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonData);
                }
                else
                {
                    Console.WriteLine($"POST thất bại với mã trạng thái: {response.StatusCode}");
                    return default;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thực hiện POST: {ex.Message}");
                return default;
            }
        }

        public async Task<T> PutAsync<T>(string endpoint, object data)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(data);
                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsync(endpoint, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonData);
                }
                else
                {
                    Console.WriteLine($"PUT thất bại với mã trạng thái: {response.StatusCode}");
                    return default;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thực hiện PUT: {ex.Message}");
                return default;
            }
        }

        public async Task<bool> DeleteAsync(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"DELETE thất bại với mã trạng thái: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thực hiện DELETE: {ex.Message}");
                return false;
            }
        }
    }
}
