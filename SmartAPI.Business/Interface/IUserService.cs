﻿using SmartAPI.Business.Services.DTO;
using SmartAPI.Infrastructure.Data.Entity;

namespace SmartAPI.Business.Interface {
    public interface IUserService
    {
        public Task<User> Register(UserRegisterDTO userRegisterRequest);
        public User GetUser(GetUserByIdDTO getUserByIdRequest);
    }
}
