using System.Collections.Generic;
using System.Linq; // UserListItemDto'yu kullanabilmek için

namespace BusinessLogicLayer.Handler.UserHandler.DTOs
{
    // Listede yer alacak her bir kullanıcının temel bilgilerini tutan iç DTO
    public class UserListItemDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsAdmin { get; set; }
    }

    // Asıl liste yanıtını taşıyan DTO
    public class GetAllUsersHandleResponse
    {
        public List<UserListItemDto> Users { get; set; } = new List<UserListItemDto>();
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}