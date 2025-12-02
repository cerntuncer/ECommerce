using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.FlagHandler.DTOs;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.FlagHandler.Queries
{
    public class GetAllFlagsHandle : IRequestHandler<GetAllFlagsHandleRequest, GetAllFlagsHandleResponse>
    {
        private readonly IFlagRepository _flagRepository;

        public GetAllFlagsHandle(IFlagRepository flagRepository)
        {
            _flagRepository = flagRepository;
        }

        public Task<GetAllFlagsHandleResponse> Handle(GetAllFlagsHandleRequest request, CancellationToken cancellationToken)
        {
            // Tüm aktif Flag'leri getirir.
            var flags = _flagRepository.GetAll();

            if (!flags.Any())
            {
                return Task.FromResult(new GetAllFlagsHandleResponse
                {
                    IsSuccess = false,
                    Message = "Kayıtlı aktif Flag bulunamadı."
                });
            }

            // Entity'leri FlagListItemDto'ya dönüştürme
            var responseList = flags.Select(f => new FlagListItemDto
            {
                FlagId = f.Id,
                Name = f.Name,
                Description = f.Description
            }).ToList();

            return Task.FromResult(new GetAllFlagsHandleResponse
            {
                IsSuccess = true,
                Flags = responseList,
                Message = $"{responseList.Count} adet Flag listelendi."
            });
        }
    }
}