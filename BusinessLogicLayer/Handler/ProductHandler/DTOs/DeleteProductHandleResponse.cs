namespace BusinessLogicLayer.Handler.ProductHandler.DTOs
{
    public class DeleteProductHandleResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}