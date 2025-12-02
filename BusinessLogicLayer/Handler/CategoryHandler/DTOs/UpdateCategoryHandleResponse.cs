namespace BusinessLogicLayer.Handler.CategoryHandler.DTOs
{
    // Güncelleme sonucunu döndürür
    public class UpdateCategoryHandleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}