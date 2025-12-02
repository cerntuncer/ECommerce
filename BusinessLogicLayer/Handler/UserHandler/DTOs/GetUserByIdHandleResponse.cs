namespace BusinessLogicLayer.Handler.UserHandler.DTOs
{
    public class GetUserByIdHandleResponse
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool Found { get; set; }
        public string Message { get; set; } = null!;
    }
}