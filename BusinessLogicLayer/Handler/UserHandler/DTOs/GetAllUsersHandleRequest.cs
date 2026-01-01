using MediatR;

namespace BusinessLogicLayer.Handler.UserHandler.DTOs
{
    // Listeleme isteği, cevabının GetAllUsersHandleResponse olacağını belirtir
    public class GetAllUsersHandleRequest : IRequest<GetAllUsersHandleResponse>
    {
        // Tüm aktif kullanıcıları listelemek için boş bir request
    }
}