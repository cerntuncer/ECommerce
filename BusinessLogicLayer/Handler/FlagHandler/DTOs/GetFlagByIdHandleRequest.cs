using MediatR;

namespace BusinessLogicLayer.Handler.FlagHandler.DTOs
{
    public class GetFlagByIdHandleRequest : IRequest<GetFlagByIdHandleResponse>
    {
        public int FlagId { get; set; }
    }
}