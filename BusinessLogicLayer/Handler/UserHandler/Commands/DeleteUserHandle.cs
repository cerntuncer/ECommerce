using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.UserHandler.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.UserHandler.Commands
{
    public class DeleteUserHandle : IRequestHandler<DeleteUserHandleRequest, DeleteUserHandleResponse>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandle(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<DeleteUserHandleResponse> Handle(DeleteUserHandleRequest request, CancellationToken cancellationToken)
        {
            var userToDelete = _userRepository.Find(request.Id);

            if (userToDelete == null)
            {
                return Task.FromResult(new DeleteUserHandleResponse { IsSuccess = false, Message = "Silinecek kullanıcı bulunamadı." });
            }

            _userRepository.Delete(userToDelete); // Soft Delete işlemi

            return Task.FromResult(new DeleteUserHandleResponse
            {
                IsSuccess = true,
                Message = $"Kullanıcı (ID: {request.Id}) başarıyla pasife çekildi."
            });
        }
    }
}