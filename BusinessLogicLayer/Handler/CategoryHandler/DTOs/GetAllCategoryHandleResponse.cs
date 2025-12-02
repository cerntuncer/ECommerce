using System.Collections.Generic;

namespace BusinessLogicLayer.Handler.CategoryHandler.DTOs
{
    // Listede yer alacak her bir Kategorinin temel bilgilerini tutan iç DTO
    public class CategoryListItemDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
    }

    // Asıl liste yanıtını taşıyan DTO
    public class GetAllCategoryHandleResponse
    {
        public List<CategoryListItemDto> Categories { get; set; } = new List<CategoryListItemDto>();
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}