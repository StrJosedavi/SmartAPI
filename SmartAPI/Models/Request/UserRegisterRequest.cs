using System.ComponentModel.DataAnnotations;

namespace SmartAPI.Application.Models.Request
{
    public class UserRegisterRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
