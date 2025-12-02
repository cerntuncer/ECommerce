using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.ProductHandler.DTOs;
using ECommerce.DatabaseAccessLayer.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.ProductHandler.Commands
{
    public class CreateProductHandle : IRequestHandler<CreateProductHandleRequest, CreateProductHandleResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateProductHandle(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public Task<CreateProductHandleResponse> Handle(CreateProductHandleRequest request, CancellationToken cancellationToken)
        {
            if (!_categoryRepository.Any(c => c.Id == request.CategoryId))
            {
                return Task.FromResult(new CreateProductHandleResponse { IsSuccess = false, Message = "Belirtilen kategori bulunamadı." });
            }

            var newProduct = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                ImageURL = request.ImageURL,
                CategoryId = request.CategoryId,
            };

            _productRepository.Add(newProduct);

            return Task.FromResult(new CreateProductHandleResponse
            {
                IsSuccess = true,
                Message = "Ürün başarıyla eklendi.",
                Id = newProduct.Id,
                Name = newProduct.Name,
                Price = newProduct.Price
            });
        }
    }
}