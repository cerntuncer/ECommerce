namespace BusinessLogicLayer.Handler.UserHandler.DTOs
{
    public class CreateUserHandleResponse
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}