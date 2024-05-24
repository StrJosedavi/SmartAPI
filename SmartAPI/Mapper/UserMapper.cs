using AutoMapper;
using SmartAPI.Models;
using RequestMapperUserRegister = SmartAPI.Business.Services.DTO;

namespace SmartAPI.Application.Mapper
{
    public class UserMapper : Profile {
        public UserMapper() {
            CreateMap<UserRegisterRequest, RequestMapperUserRegister.UserRegisterDTO>();
            CreateMap<GetUserByIdRequest, RequestMapperUserRegister.GetUserByIdDTO>();
        }
    }
}
