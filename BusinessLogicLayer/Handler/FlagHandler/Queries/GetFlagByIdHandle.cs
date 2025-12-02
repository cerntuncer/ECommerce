using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.FlagHandler.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.FlagHandler.Queries
{
    public class GetFlagByIdHandle : IRequestHandler<GetFlagByIdHandleRequest, GetFlagByIdHandleResponse>
    {
        private readonly IFlagRepository _flagRepository;

        public GetFlagByIdHandle(IFlagRepository flagRepository)
        {
            _flagRepository = flagRepository;
        }

        public Task<GetFlagByIdHandleResponse> Handle(GetFlagByIdHandleRequest request, CancellationToken cancellationToken)
        {
            var flag = _flagRepository.Find(request.FlagId);

            if (flag == null)
            {
                return Task.FromResult(new GetFlagByIdHandleResponse
                {
                    IsSuccess = false,
                    Message = $"Flag bulunamadı. ID: {request.FlagId}"
                });
            }

            // Entity'den DTO'ya dönüşüm
            return Task.FromResult(new GetFlagByIdHandleResponse
            {
                FlagId = flag.Id,
                Name = flag.Name,
                Description = flag.Description,
                IsSuccess = true,
                Message = $"Flag başarıyla getirildi. ID: {flag.Id}"
            });
        }
    }
}