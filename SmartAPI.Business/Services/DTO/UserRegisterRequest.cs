﻿namespace SmartAPI.Business.Services.DTO {
    public class UserRegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}
