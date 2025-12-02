using MediatR;

namespace BusinessLogicLayer.Handler.FlagHandler.DTOs
{
    public class GetAllFlagsHandleRequest : IRequest<GetAllFlagsHandleResponse>
    {
        // Tüm Flag'leri listelemek için boş request
    }
}