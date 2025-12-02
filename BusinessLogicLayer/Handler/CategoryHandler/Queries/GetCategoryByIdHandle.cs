using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.CategoryHandler.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.CategoryHandler.Queries
{
    public class GetCategoryByIdHandle : IRequestHandler<GetCategoryByIdHandleRequest, GetCategoryByIdHandleResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdHandle(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<GetCategoryByIdHandleResponse> Handle(GetCategoryByIdHandleRequest request, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.Find(request.Id);

            if (category == null)
            {
                return Task.FromResult(new GetCategoryByIdHandleResponse
                {
                    Found = false,
                    Message = "Kategori bulunamadı."
                });
            }

            return Task.FromResult(new GetCategoryByIdHandleResponse
            {
                Found = true,
                Message = "Kategori başarıyla bulundu.",
                Id = category.Id,
                Name = category.Name
            });
        }
    }
}