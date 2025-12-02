using MediatR;

namespace BusinessLogicLayer.Handler.UserHandler.DTOs
{
    public class GetUserByIdHandleRequest : IRequest<GetUserByIdHandleResponse>
    {
        public int Id { get; set; }
    }
}