

using System.Net.Http.Headers;

namespace Base.Context
{
    public class ApiFetch
    {
        private static readonly ApiFetch _instance = new ApiFetch();
        private static readonly HttpClient _httpClient;

        static ApiFetch()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://127.0.0.1:5173/api/v1"),
                Timeout = TimeSpan.FromSeconds(30)
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        private ApiFetch() { }

        public static ApiFetch Instance
        {
            get
            {
                return _instance;
            }
        }

        public HttpClient GetHttpClient()
        {
            return _httpClient;
        }
    }
}
