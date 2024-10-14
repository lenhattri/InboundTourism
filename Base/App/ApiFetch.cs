using System;
using System.Net.Http;
using System.Net.Http.Headers;

public static class ApiFetch
{
    private static readonly HttpClient _httpClient;

    static ApiFetch()
    {
        _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30) // Thiết lập thời gian chờ mặc định
        };

        // Đặt các tiêu đề mặc định
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; HttpClientApp/1.0)");

        // Thêm các cấu hình khác nếu cần
    }

    // Phương thức để lấy đối tượng HttpClient duy nhất
    public static HttpClient GetHttpClient()
    {
        return _httpClient;
    }
}
