using Microsoft.AspNetCore.Components.Forms;
using SmartAPI.Business.Services.Messages;
using System.ComponentModel.DataAnnotations;

namespace SmartAPI.Application.Models.Request
{
    public class UserRegisterRequest
    {
        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(UserMessage), ErrorMessageResourceName = "VALIDATIONREQUEST01")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessageResourceType = typeof(UserMessage), ErrorMessageResourceName = "VALIDATIONREQUEST03")]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessageResourceType = typeof(UserMessage), ErrorMessageResourceName = "VALIDATIONREQUEST03")]
        [Compare(nameof(Password), ErrorMessageResourceType = typeof(UserMessage), ErrorMessageResourceName = "VALIDATIONREQUEST02")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress(ErrorMessageResourceType = typeof(UserMessage), ErrorMessageResourceName = "VALIDATIONREQUEST04")]
        public string Email { get; set; }
    }
}
