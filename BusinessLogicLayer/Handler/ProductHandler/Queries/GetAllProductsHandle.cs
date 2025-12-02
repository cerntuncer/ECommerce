using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.ProductHandler.DTOs; // DTO'ları bulmak için EKLE
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.ProductHandler.Queries
{
    public class GetAllProductsHandle : IRequestHandler<GetAllProductsHandleRequest, GetAllProductsHandleResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandle(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<GetAllProductsHandleResponse> Handle(GetAllProductsHandleRequest request, CancellationToken cancellationToken)
        {
            // Tüm aktif Ürünleri getirir.
            var products = _productRepository.GetAll();

            if (!products.Any())
            {
                return Task.FromResult(new GetAllProductsHandleResponse
                {
                    IsSuccess = false,
                    Message = "Kayıtlı aktif Ürün bulunamadı."
                });
            }

            // Entity'leri ProductListItemDto'ya dönüştürme
            var responseList = products.Select(p => new ProductListItemDto
            {
                ProductId = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                AverageRating = p.AverageRating,
                // İlişkili alanlar (CategoryId ve FlagId)
                CategoryId = p.CategoryId,
                FlagId = p.FlagId ?? 0,
            }).ToList();

            return Task.FromResult(new GetAllProductsHandleResponse
            {
                IsSuccess = true,
                Products = responseList,
                Message = $"{responseList.Count} adet Ürün listelendi."
            });
        }
    }
}