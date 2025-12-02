using System.Collections.Generic;

namespace BusinessLogicLayer.Handler.FlagHandler.DTOs
{
    // Listede yer alacak her bir Flag'in temel bilgilerini tutan iç DTO
    public class FlagListItemDto
    {
        public int FlagId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }

    // Asıl liste yanıtını taşıyan DTO
    public class GetAllFlagsHandleResponse
    {
        public List<FlagListItemDto> Flags { get; set; } = new List<FlagListItemDto>();
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}