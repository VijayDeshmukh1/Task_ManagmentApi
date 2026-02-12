using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_ManagmentApi.DTOs;
using Task_ManagmentApi.Services;

namespace Task_ManagmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                var userResponse = await _authService.RegisterAsync(registerDto);
                return Ok(userResponse);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An Error Occoured during registration", details = ex.Message });
            }
        }
    }
}
