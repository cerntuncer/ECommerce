using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.ProductHandler.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.ProductHandler.Queries
{
    public class GetProductByIdHandle : IRequestHandler<GetProductByIdHandleRequest, GetProductByIdHandleResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IFlagRepository _flagRepository;

        public GetProductByIdHandle(IProductRepository productRepository, IFlagRepository flagRepository)
        {
            _productRepository = productRepository;
            _flagRepository = flagRepository;
        }

        public Task<GetProductByIdHandleResponse> Handle(GetProductByIdHandleRequest request, CancellationToken cancellationToken)
        {
            var product = _productRepository.Find(request.Id);

            if (product == null)
            {
                return Task.FromResult(new GetProductByIdHandleResponse
                {
                    IsSuccess = false,
                    Message = "Ürün bulunamadı."
                });
            }

            var flag = product.FlagId.HasValue ? _flagRepository.Find(product.FlagId.Value) : null;

            return Task.FromResult(new GetProductByIdHandleResponse
            {
                IsSuccess = true,
                Message = "Ürün başarıyla bulundu.",
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                FlagName = flag?.Name
            });
        }
    }
}