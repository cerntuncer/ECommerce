using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Services.Auth;
using ECommerce.DatabaseAccessLayer.Entities;
using System.Threading.Tasks;
using System;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLogicLayer.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository; // Kullanıcı verilerine erişim
        private readonly IJwtTokenService _tokenService; // JWT oluşturucu

        public AuthService(IUserRepository userRepository, IJwtTokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        // --- Yardımcı Metot: Şifre Hashleme (Güvenlik İçin Kritik) ---
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            // 1. Kullanıcıyı e-posta ile bul
            var user = _userRepository.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı.");
            }

            // 2. Girilen şifreyi Hashle ve kayıtlı Hash ile karşılaştır
            var hashedPassword = HashPassword(password);

            if (user.PasswordHash != hashedPassword)
            {
                throw new Exception("Şifre hatalı.");
            }

            // 3. Doğrulama başarılıysa Token oluştur ve döndür
            return _tokenService.GenerateToken(user);
        }

        public async Task<User> RegisterAsync(string email, string password, string firstName, string lastName, bool isAdmin = false)
        {
            // 1. Kullanıcının zaten var olup olmadığını kontrol et
            if (_userRepository.Any(u => u.Email == email))
            {
                throw new Exception("Bu e-posta adresi zaten kullanımda.");
            }

            // 2. Şifreyi Hashle
            var hashedPassword = HashPassword(password);

            // 3. Yeni Kullanıcıyı oluştur
            var newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PasswordHash = hashedPassword,
                IsAdmin = isAdmin,
                CreatedDate = DateTime.UtcNow // BaseEntity tarafından zaten ayarlanıyor
            };

            // 4. Veri tabanına kaydet
            _userRepository.Add(newUser);

            return newUser;
        }
    }
}