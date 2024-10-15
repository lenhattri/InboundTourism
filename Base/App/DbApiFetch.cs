

using System.Net.Http.Headers;

namespace Base.Context
{
    public class DbApiFetch
    {
        private static readonly DbApiFetch _instance = new DbApiFetch();
        private static readonly HttpClient _httpClient;

        static DbApiFetch()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://127.0.0.1:5173/api/v1"),
                Timeout = TimeSpan.FromSeconds(30)
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        private DbApiFetch() { }

        public static DbApiFetch Instance
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
