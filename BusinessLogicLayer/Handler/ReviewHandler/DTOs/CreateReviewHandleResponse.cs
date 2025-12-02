namespace BusinessLogicLayer.Handler.ReviewHandler.DTOs
{
    public class CreateReviewHandleResponse
    {
        public int ReviewId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
    }
}