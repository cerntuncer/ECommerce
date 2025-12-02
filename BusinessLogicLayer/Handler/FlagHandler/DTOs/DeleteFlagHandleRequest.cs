using MediatR;

namespace BusinessLogicLayer.Handler.FlagHandler.DTOs
{
    public class DeleteFlagHandleRequest : IRequest<DeleteFlagHandleResponse>
    {
        public int FlagId { get; set; }
    }
}