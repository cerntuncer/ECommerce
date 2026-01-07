using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Services;
using BusinessLogicLayer.Handler.ReviewHandler.DTOs;

namespace PresentationLayer.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApiService _apiService;

        public AdminController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> SuspiciousReviews()
        {
            // 1. API'den ana paket yanıtını alıyoruz
            var response = await _apiService.GetAllAsync<GetAllReviewsHandleResponse>("Review");

            // 2. DÜZELTME: Response bir liste değil, tek bir nesnedir. 
            // Bu yüzden FirstOrDefault() KULLANILMAZ. Doğrudan içindeki Reviews listesine erişilir.
            var allReviews = response?.Reviews ?? new List<ReviewListItemDto>();

            // 3. View'a listeyi gönderiyoruz
            return View(allReviews);
        }
    }
}