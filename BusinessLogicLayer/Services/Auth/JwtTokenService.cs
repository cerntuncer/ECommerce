using BusinessLogicLayer.Services.Auth;
using ECommerce.DatabaseAccessLayer.Entities;
using Microsoft.Extensions.Configuration; // Appsettings'ten ayar çekmek için gerekli
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;

namespace BusinessLogicLayer.Services.Auth
{
    // Bu sınıf, appsettings.json dosyasından ayarları okumak için IConfiguration'ı kullanır.
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            // Claim'ler, token içine gömülen kullanıcı bilgileridir.
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                // Kullanıcının yönetici olup olmamasına göre rol eklenir
                new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User")
            };

            // Appsettings.json'dan gizli anahtar, yayıncı ve hedef kitle bilgileri çekilir.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7), // Token'ın geçerlilik süresi
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}