using System.Net.Http.Json;

namespace PresentationLayer.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public ApiService(HttpClient httpClient) => _httpClient = httpClient;

        // DOĞRU HALİ: Geriye List<T> değil, T (Response Nesnesi) döner
        public async Task<T?> GetAllAsync<T>(string endpoint)
        {
            try
            {
                // API artık { "Products": [...], "IsSuccess": true } şeklinde bir nesne dönüyor
                return await _httpClient.GetFromJsonAsync<T>(endpoint);
            }
            catch (Exception ex)
            {
                // Loglama yapabilirsin
                return default;
            }
        }

        public async Task<T?> GetByIdAsync<T>(string endpoint, int id)
            => await _httpClient.GetFromJsonAsync<T>($"{endpoint}/{id}");
    }
}