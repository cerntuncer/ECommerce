using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.CategoryHandler.DTOs;
using ECommerce.DatabaseAccessLayer.Entities;
using ECommerce.DatabaseAccessLayer.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.CategoryHandler.Commands
{
    public class CreateCategoryHandle : IRequestHandler<CreateCategoryHandleRequest, CreateCategoryHandleResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryHandle(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<CreateCategoryHandleResponse> Handle(CreateCategoryHandleRequest request, CancellationToken cancellationToken)
        {
            if (_categoryRepository.Any(c => c.Name == request.Name))
            {
                return Task.FromResult(new CreateCategoryHandleResponse
                {
                    IsSuccess = false,
                    Message = "Bu kategori adı zaten mevcut."
                });
            }

            var newCategory = new Category { Name = request.Name };
            _categoryRepository.Add(newCategory);

            return Task.FromResult(new CreateCategoryHandleResponse
            {
                IsSuccess = true,
                Message = "Kategori başarıyla oluşturuldu.",
                Id = newCategory.Id,
                Name = newCategory.Name
            });
        }
    }
}