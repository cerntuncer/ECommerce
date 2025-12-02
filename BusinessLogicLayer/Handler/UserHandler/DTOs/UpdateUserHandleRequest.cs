using MediatR;

namespace BusinessLogicLayer.Handler.UserHandler.DTOs
{
    public class UpdateUserHandleRequest : IRequest<UpdateUserHandleResponse>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsAdmin { get; set; }
    }
}