using MediatR;

namespace BusinessLogicLayer.Handler.UserHandler.DTOs
{
    public class DeleteUserHandleRequest : IRequest<DeleteUserHandleResponse>
    {
        public int Id { get; set; }
    }
}