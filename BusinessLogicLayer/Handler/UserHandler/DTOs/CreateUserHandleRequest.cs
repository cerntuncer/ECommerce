using MediatR;
using BusinessLogicLayer.Handler.UserHandler.DTOs; // Tüm DTO'ları görmek için
namespace BusinessLogicLayer.Handler.UserHandler.DTOs
{
    public class CreateUserHandleRequest : IRequest<CreateUserHandleResponse>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}