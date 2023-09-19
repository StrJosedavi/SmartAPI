﻿using System.ComponentModel.DataAnnotations;

namespace SmartAPI.Models.Request
{
    public class UserRegisterRequest
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
