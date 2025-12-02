using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.UserHandler.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.UserHandler.Queries
{
    public class GetUserByIdHandle : IRequestHandler<GetUserByIdHandleRequest, GetUserByIdHandleResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandle(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<GetUserByIdHandleResponse> Handle(GetUserByIdHandleRequest request, CancellationToken cancellationToken)
        {
            var user = _userRepository.Find(request.Id);

            if (user == null)
            {
                return Task.FromResult(new GetUserByIdHandleResponse { Found = false, Message = "Kullanıcı bulunamadı." });
            }

            return Task.FromResult(new GetUserByIdHandleResponse
            {
                Found = true,
                Message = "Kullanıcı başarıyla bulundu.",
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsAdmin = user.IsAdmin
            });
        }
    }
}