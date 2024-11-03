using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Base.Context.App;
using Newtonsoft.Json;

namespace Base.Utils.Fetch
{
    public class FetchService
    {
        private static readonly Lazy<FetchService> _instance = new Lazy<FetchService>(() => new FetchService());
        private readonly HttpClient _httpClient;


        private FetchService()
        {
            _httpClient = DbApiFetch.Instance.GetHttpClient();
        }


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
                    throw new Exception($"GET request failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching data.", ex);
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
                    throw new Exception($"POST request failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while posting data.", ex);
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
                    throw new Exception($"PUT request failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while putting data.", ex);
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
                    throw new Exception($"DELETE request failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting data.", ex);
            }

        }
    }
}
