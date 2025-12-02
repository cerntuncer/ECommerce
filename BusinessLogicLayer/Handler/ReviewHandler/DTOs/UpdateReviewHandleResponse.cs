namespace BusinessLogicLayer.Handler.ReviewHandler.DTOs
{
    public class UpdateReviewHandleResponse
    {
        public int ReviewId { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}