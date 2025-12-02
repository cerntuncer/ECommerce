using MediatR;

namespace BusinessLogicLayer.Handler.FlagHandler.DTOs
{
    public class CreateFlagHandleRequest : IRequest<CreateFlagHandleResponse>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}