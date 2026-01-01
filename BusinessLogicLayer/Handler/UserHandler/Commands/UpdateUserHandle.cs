using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.UserHandler.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.UserHandler.Commands
{
    public class UpdateUserHandle : IRequestHandler<UpdateUserHandleRequest, UpdateUserHandleResponse>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandle(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UpdateUserHandleResponse> Handle(UpdateUserHandleRequest request, CancellationToken cancellationToken)
        {
            var userToUpdate = _userRepository.Find(request.Id);

            if (userToUpdate == null)
            {
                return Task.FromResult(new UpdateUserHandleResponse { IsSuccess = false, Message = "Güncellenecek kullanıcı bulunamadı." });
            }

            userToUpdate.FirstName = request.FirstName;
            userToUpdate.LastName = request.LastName;
            userToUpdate.IsAdmin = request.IsAdmin;

            _userRepository.Update(userToUpdate);

            return Task.FromResult(new UpdateUserHandleResponse
            {
                IsSuccess = true,
                Message = "Kullanıcı bilgileri başarıyla güncellendi."
            });
        }
    }
}