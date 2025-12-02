using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.CategoryHandler.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.CategoryHandler.Commands
{
    public class DeleteCategoryHandle : IRequestHandler<DeleteCategoryHandleRequest, DeleteCategoryHandleResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryHandle(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<DeleteCategoryHandleResponse> Handle(DeleteCategoryHandleRequest request, CancellationToken cancellationToken)
        {
            var categoryToDelete = _categoryRepository.Find(request.Id);

            if (categoryToDelete == null)
            {
                return Task.FromResult(new DeleteCategoryHandleResponse
                {
                    IsSuccess = false,
                    Message = "Silinecek kategori bulunamadı."
                });
            }

            // Soft Delete işlemi (Eğer repository bu metodu kullanıyorsa)
            _categoryRepository.Delete(categoryToDelete);

            return Task.FromResult(new DeleteCategoryHandleResponse
            {
                IsSuccess = true,
                Message = $"Kategori (ID: {request.Id}) başarıyla pasife çekildi."
            });
        }
    }
}