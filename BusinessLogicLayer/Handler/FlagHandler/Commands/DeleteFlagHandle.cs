using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.FlagHandler.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.FlagHandler.Commands
{
    public class DeleteFlagHandle : IRequestHandler<DeleteFlagHandleRequest, DeleteFlagHandleResponse>
    {
        private readonly IFlagRepository _flagRepository;

        public DeleteFlagHandle(IFlagRepository flagRepository)
        {
            _flagRepository = flagRepository;
        }

        public Task<DeleteFlagHandleResponse> Handle(DeleteFlagHandleRequest request, CancellationToken cancellationToken)
        {
            var flagToDelete = _flagRepository.Find(request.FlagId);

            if (flagToDelete == null)
            {
                return Task.FromResult(new DeleteFlagHandleResponse
                {
                    IsSuccess = false,
                    Message = $"Silinecek Flag bulunamadı. ID: {request.FlagId}"
                });
            }

            // Soft Delete işlemi
            _flagRepository.Delete(flagToDelete);

            return Task.FromResult(new DeleteFlagHandleResponse
            {
                IsSuccess = true,
                Message = $"Flag başarıyla silindi (Soft Delete). ID: {request.FlagId}"
            });
        }
    }
}