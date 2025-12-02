using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.UserHandler.DTOs;
using ECommerce.DatabaseAccessLayer.Entities;
using MediatR;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.UserHandler.Commands
{
    public class CreateUserHandle : IRequestHandler<CreateUserHandleRequest, CreateUserHandleResponse>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandle(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public Task<CreateUserHandleResponse> Handle(CreateUserHandleRequest request, CancellationToken cancellationToken)
        {
            if (_userRepository.Any(u => u.Email == request.Email))
            {
                return Task.FromResult(new CreateUserHandleResponse
                {
                    Success = false,
                    Message = "Bu e-posta adresi zaten kullanımda."
                });
            }

            var hashedPassword = HashPassword(request.Password);

            var newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = hashedPassword,
                IsAdmin = request.IsAdmin
            };

            _userRepository.Add(newUser);

            return Task.FromResult(new CreateUserHandleResponse
            {
                Success = true,
                Message = "Kullanıcı başarıyla kaydedildi.",
                Id = newUser.Id,
                Email = newUser.Email
            });
        }
    }
}