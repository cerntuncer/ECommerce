using MediatR;

namespace BusinessLogicLayer.Handler.FlagHandler.DTOs
{
    public class UpdateFlagHandleRequest : IRequest<UpdateFlagHandleResponse>
    {
        public int FlagId { get; set; }
        // Güncellenebilecek alanlar
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}