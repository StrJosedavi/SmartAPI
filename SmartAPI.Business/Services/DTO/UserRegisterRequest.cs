using System.ComponentModel.DataAnnotations;

namespace SmartAPI.Business.Services.DTO
{
    public class UserRegisterRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string TokenCode { get; set; }
    }
}
