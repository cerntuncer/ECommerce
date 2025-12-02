using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.FlagHandler.DTOs;
using ECommerce.DatabaseAccessLayer.Entities;
using ECommerce.DatabaseAccessLayer.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.FlagHandler.Commands
{
    public class CreateFlagHandle : IRequestHandler<CreateFlagHandleRequest, CreateFlagHandleResponse>
    {
        private readonly IFlagRepository _flagRepository;

        public CreateFlagHandle(IFlagRepository flagRepository)
        {
            _flagRepository = flagRepository;
        }

        public Task<CreateFlagHandleResponse> Handle(CreateFlagHandleRequest request, CancellationToken cancellationToken)
        {
            var newFlag = new Flag
            {
                Name = request.Name,
                Description = request.Description
                // CreatedDate otomatik olarak BaseEntity tarafından atanır (Eğer BaseEntity'de varsa)
            };

            _flagRepository.Add(newFlag);

            return Task.FromResult(new CreateFlagHandleResponse
            {
                FlagId = newFlag.Id,
                IsSuccess = true,
                Message = $"Flag başarıyla oluşturuldu. ID: {newFlag.Id}"
            });
        }
    }
}