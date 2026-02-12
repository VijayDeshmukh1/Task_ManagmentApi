using Task_ManagmentApi.DTOs;

namespace Task_ManagmentApi.Services
{
    public interface IAuthService
    {
        Task<UserResponseDto> RegisterAsync(RegisterDto registerDto);
    }
}
