namespace BusinessLogicLayer.Handler.CategoryHandler.DTOs
{
    // Silme sonucunu döndürür
    public class DeleteCategoryHandleResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}