using ECommerce.DatabaseAccessLayer.Entities;

namespace BusinessLogicLayer.Services.Auth
{
    public interface IJwtTokenService
    {
        // Verilen kullanıcı için JWT (JSON Web Token) oluşturur.
        string GenerateToken(User user);
    }
}