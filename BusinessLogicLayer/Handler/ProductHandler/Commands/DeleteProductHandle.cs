using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.ProductHandler.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.ProductHandler.Commands
{
    public class DeleteProductHandle : IRequestHandler<DeleteProductHandleRequest, DeleteProductHandleResponse>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandle(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<DeleteProductHandleResponse> Handle(DeleteProductHandleRequest request, CancellationToken cancellationToken)
        {
            var productToDelete = _productRepository.Find(request.Id);

            if (productToDelete == null)
            {
                return Task.FromResult(new DeleteProductHandleResponse
                {
                    IsSuccess = false,
                    Message = "Silinecek ürün bulunamadı."
                });
            }

            _productRepository.Delete(productToDelete); // Soft Delete

            return Task.FromResult(new DeleteProductHandleResponse
            {
                IsSuccess = true,
                Message = $"Ürün (ID: {request.Id}) başarıyla pasife çekildi."
            });
        }
    }
}