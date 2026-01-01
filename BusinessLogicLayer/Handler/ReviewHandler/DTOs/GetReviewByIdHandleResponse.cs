namespace BusinessLogicLayer.Handler.ReviewHandler.DTOs
{
    public class GetReviewByIdHandleResponse
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; } = null!;
        public DateTime ReviewDate { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}