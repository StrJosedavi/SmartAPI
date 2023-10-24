using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartAPI.Application.Models.Request;
using SmartAPI.Business.Interface;
using SmartAPI.Business.Services.DTO;
using SmartAPI.Business.Services.Messages;
using SmartAPI.Infrastructure.Data.Entity;

namespace SmartAPI.Application.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {

        private readonly IAuthenticateService _authenticationService;
        private readonly IMapper _mapper;
        public AuthenticateController(IAuthenticateService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        /// <summary>
        /// Autenticação de usuário
        /// </summary>
        /// <param name="loginRequest">Dados a ser enviado para registro de usuário.</param>
        /// <returns>Sessão do usuário</returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn([FromBody] LoginRequest loginRequest) 
        {
            var RequestMapper = _mapper.Map<UserLoginDTO>(loginRequest);
            var LoginResult = await _authenticationService.Login(RequestMapper);

            return Ok(new {Success = true, Session = LoginResult, Message =  UserMessage.AUTHSUCCESS});
        }
    }
}
