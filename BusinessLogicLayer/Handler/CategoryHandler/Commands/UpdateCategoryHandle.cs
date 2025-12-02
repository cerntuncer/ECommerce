using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.CategoryHandler.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessLogicLayer.Handler.CategoryHandler.Commands
{
    public class UpdateCategoryHandle : IRequestHandler<UpdateCategoryHandleRequest, UpdateCategoryHandleResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryHandle(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<UpdateCategoryHandleResponse> Handle(UpdateCategoryHandleRequest request, CancellationToken cancellationToken)
        {
            var categoryToUpdate = _categoryRepository.Find(request.Id);

            if (categoryToUpdate == null)
            {
                return Task.FromResult(new UpdateCategoryHandleResponse
                {
                    IsSuccess = false,
                    Message = "Güncellenecek kategori bulunamadı."
                });
            }

            // Başka bir kategorinin aynı adı kullanıp kullanmadığını kontrol et (kendisi hariç)
            if (_categoryRepository.Any(c => c.Name == request.Name && c.Id != request.Id))
            {
                return Task.FromResult(new UpdateCategoryHandleResponse
                {
                    IsSuccess = false,
                    Message = "Bu kategori adı zaten başka bir kategoride mevcut."
                });
            }

            categoryToUpdate.Name = request.Name;
            _categoryRepository.Update(categoryToUpdate);

            return Task.FromResult(new UpdateCategoryHandleResponse
            {
                IsSuccess = true,
                Message = "Kategori başarıyla güncellendi.",
                Id = categoryToUpdate.Id,
                Name = categoryToUpdate.Name
            });
        }
    }
}