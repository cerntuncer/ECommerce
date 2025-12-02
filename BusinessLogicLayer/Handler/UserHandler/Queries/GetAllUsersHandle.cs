using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.UserHandler.DTOs; // Tüm DTO'ları bulabilmek için EKLE
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.UserHandler.Queries
{
    // Handler, GetAllUsersRequest'i alır ve GetAllUsersHandleResponse döner.
    public class GetAllCategoriesHandleRequest : IRequestHandler<DTOs.GetAllCategoriesHandleRequest, GetAllCategoriesHandleResponse>
    {
        private readonly IUserRepository _userRepository;

        // Constructor Injection
        public GetAllCategoriesHandleRequest(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<GetAllCategoriesHandleResponse> Handle(DTOs.GetAllCategoriesHandleRequest request, CancellationToken cancellationToken)
        {
            // Tüm aktif kullanıcıları getirir.
            var users = _userRepository.GetAll();

            if (!users.Any())
            {
                return Task.FromResult(new GetAllCategoriesHandleResponse
                {
                    IsSuccess = false,
                    Message = "Kayıtlı aktif kullanıcı bulunamadı."
                });
            }

            // Entity'leri UserListItemDto'ya dönüştürme
            var responseList = users.Select(u => new UserListItemDto
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                IsAdmin = u.IsAdmin
            }).ToList();

            // Sonuç DTO'sunu hazırlama
            return Task.FromResult(new GetAllCategoriesHandleResponse
            {
                IsSuccess = true,
                Users = responseList,
                Message = $"{responseList.Count} adet kullanıcı listelendi."
            });
        }
    }
}