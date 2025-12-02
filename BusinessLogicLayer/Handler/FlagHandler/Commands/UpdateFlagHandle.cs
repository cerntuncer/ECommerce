using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.FlagHandler.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.FlagHandler.Commands
{
    public class UpdateFlagHandle : IRequestHandler<UpdateFlagHandleRequest, UpdateFlagHandleResponse>
    {
        private readonly IFlagRepository _flagRepository;

        public UpdateFlagHandle(IFlagRepository flagRepository)
        {
            _flagRepository = flagRepository;
        }

        public Task<UpdateFlagHandleResponse> Handle(UpdateFlagHandleRequest request, CancellationToken cancellationToken)
        {
            var flagToUpdate = _flagRepository.Find(request.FlagId);

            if (flagToUpdate == null)
            {
                return Task.FromResult(new UpdateFlagHandleResponse
                {
                    IsSuccess = false,
                    Message = $"Güncellenecek Flag bulunamadı. ID: {request.FlagId}"
                });
            }

            // Alanları güncelle
            flagToUpdate.Name = request.Name;
            flagToUpdate.Description = request.Description;

            _flagRepository.Update(flagToUpdate); // UpdateDate BaseEntity tarafından güncellenir

            return Task.FromResult(new UpdateFlagHandleResponse
            {
                FlagId = flagToUpdate.Id,
                IsSuccess = true,
                Message = $"Flag başarıyla güncellendi. ID: {flagToUpdate.Id}"
            });
        }
    }
}