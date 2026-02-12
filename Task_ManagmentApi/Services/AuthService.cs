using Task_ManagmentApi.Data;
using Task_ManagmentApi.DTOs;
using Task_ManagmentApi.Models;

namespace Task_ManagmentApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            //check if user with the same email or username already exists
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == registerDto.Email || u.UserName == registerDto.UserName);

            if (existingUser != null)
            {
                throw new Exception("User with the same email or username already exists.");

            }
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            var user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user); //in memory data inserted
            await _context.SaveChangesAsync(); //save changes to database

            return new UserResponseDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };

        }
    }
}
