using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.CategoryHandler.DTOs; // DTO'ları bulmak için EKLE
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.CategoryHandler.Queries
{
    public class GetAllCategoryHandle : IRequestHandler<GetAllCategoryHandleRequest, GetAllCategoryHandleResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoryHandle(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<GetAllCategoryHandleResponse> Handle(GetAllCategoryHandleRequest request, CancellationToken cancellationToken)
        {
            // Tüm aktif Kategorileri getirir.
            var categories = _categoryRepository.GetAll();

            if (!categories.Any())
            {
                return Task.FromResult(new GetAllCategoryHandleResponse
                {
                    IsSuccess = false,
                    Message = "Kayıtlı aktif Kategori bulunamadı."
                });
            }

            // Entity'leri CategoryListItemDto'ya dönüştürme
            var responseList = categories.Select(c => new CategoryListItemDto
            {
                // Kategori tablosunda CategoryID ve Name alanları mevcuttur.
                CategoryId = c.Id,
                Name = c.Name
            }).ToList();

            return Task.FromResult(new GetAllCategoryHandleResponse
            {
                IsSuccess = true,
                Categories = responseList,
                Message = $"{responseList.Count} adet Kategori listelendi."
            });
        }
    }
}