using System.ComponentModel.DataAnnotations;

namespace Task_ManagmentApi.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage ="User Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "User Name must be between 3 and 50 characters")]
        public string UserName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }= string.Empty;


        [Required(ErrorMessage = "Password is Required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; } = string.Empty;
    }
}
