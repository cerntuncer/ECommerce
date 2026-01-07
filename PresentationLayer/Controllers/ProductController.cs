using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Services;
using BusinessLogicLayer.Handler.ProductHandler.DTOs;

namespace PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApiService _apiService;
        public ProductController(ApiService apiService) => _apiService = apiService;

        public async Task<IActionResult> Index()
        {
            // API'den ana paketi (GetAllProductsHandleResponse) alıyoruz
            var result = await _apiService.GetAllAsync<GetAllProductsHandleResponse>("Product");

            // Paket başarılıysa içindeki Products listesini View'a gönder, değilse boş liste gönder
            var model = result?.Products ?? new List<ProductListItemDto>();

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _apiService.GetByIdAsync<GetProductByIdHandleResponse>("Product", id);
            if (result == null || !result.IsSuccess) return NotFound();
            return View(result);
        }
    }
}