﻿using System.ComponentModel.DataAnnotations;

namespace SmartAPI.Models.Request
{
    public class UserRegisterRequest
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
