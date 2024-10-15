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
            BaseAddress = new Uri("http://127.0.0.1:5173/api/v1"),
            Timeout = TimeSpan.FromSeconds(30)
        };


        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public static HttpClient GetHttpClient()
    {
        return _httpClient;
    }
}
