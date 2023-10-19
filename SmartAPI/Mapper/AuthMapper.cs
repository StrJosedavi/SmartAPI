using AutoMapper;
using SmartAPI.Application.Models.Request;
using RequestMapperUserLogin = SmartAPI.Business.Services.DTO;

namespace SmartAPI.Application.Mapper {
    public class AuthMapper : Profile {
        public AuthMapper() {
            CreateMap<LoginRequest, RequestMapperUserLogin.UserLoginDTO>();
        }
    }
}
