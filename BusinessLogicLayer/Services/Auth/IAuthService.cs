using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using ECommerce.DatabaseAccessLayer.Entities;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Auth
{
    public interface IAuthService
    {
        // Kullanıcıyı e-posta ve şifre ile doğrular, başarılı olursa token döndürür.
        Task<string> LoginAsync(string email, string password);

        // Yeni kullanıcı kaydı. Başarılı olursa kullanıcı nesnesini döndürür.
        Task<User> RegisterAsync(string email, string password, string firstName, string lastName, bool isAdmin = false);

        // Şifre Hashleme/Doğrulama işlemleri için yardımcı metotlar (isteğe bağlı)
    }
}