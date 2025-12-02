using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.ProductHandler.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.ProductHandler.Commands
{
    public class UpdateProductHandle : IRequestHandler<UpdateProductHandleRequest, UpdateProductHandleResponse>
    {
        private readonly IProductRepository _productRepository; 
        private readonly ICategoryRepository _categoryRepository;

        public UpdateProductHandle(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public Task<UpdateProductHandleResponse> Handle(UpdateProductHandleRequest request, CancellationToken cancellationToken)
        {
            var productToUpdate = _productRepository.Find(request.Id);

            if (productToUpdate == null)
            {
                return Task.FromResult(new UpdateProductHandleResponse { IsSuccess = false, Message = "Güncellenecek ürün bulunamadı." });
            }

            if (!_categoryRepository.Any(c => c.Id == request.CategoryId))
            {
                return Task.FromResult(new UpdateProductHandleResponse { IsSuccess = false, Message = "Belirtilen kategori bulunamadı." });
            }

            productToUpdate.Name = request.Name;
            productToUpdate.Description = request.Description;
            productToUpdate.Price = request.Price;
            productToUpdate.StockQuantity = request.StockQuantity;
            productToUpdate.ImageURL = request.ImageURL;
            productToUpdate.CategoryId = request.CategoryId;

            _productRepository.Update(productToUpdate);

            return Task.FromResult(new UpdateProductHandleResponse
            {
                IsSuccess = true,
                Message = "Ürün başarıyla güncellendii."
            });
        }
    }
}