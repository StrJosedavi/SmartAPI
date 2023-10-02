using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAPI.Application.Mapper;
using SmartAPI.Application.Models.Request;
using SmartAPI.Application.Models.Result;
using SmartAPI.Business.Interface;
using SmartAPI.Business.Services.Messages;
using SmartAPI.Infrastructure.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SmartAPI.Application.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserMapper _userMapper;
        public UserController(IUserService userService, UserMapper userMapper)
        {
           _userService = userService;
           _userMapper = userMapper;
        }

        /// <summary>
        /// Criação de usuário
        /// </summary>
        /// <param name="userRegisterRequest">Dados a ser enviado para registro de usuário.</param>
        /// <returns>Sucesso na criação de usuário</returns>

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        [ProducesResponseType(200, Type = typeof(Response))]    
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Register(UserRegisterRequest userRegisterRequest)
        {
            var RequestMapper = _userMapper.UserRequestRegisterMapper(userRegisterRequest);
            _userService.Register(RequestMapper);
            return Ok(new Response(){ Success = true, Data = null, Message = UserMessage.CREATE});
        }

        /// <summary>
        /// Busca de usuário
        /// </summary>
        /// <param name="userId">Dados de usuário para busca.</param>
        /// <returns>Sucesso na busca de usuário</returns>

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(200, Type = typeof(Response))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Authorize]
        public IActionResult GetUser([FromQuery][Required(ErrorMessage = "Necessário UserId")][Range(1, long.MaxValue)] long userId)
        {
            User user = _userService.GetUser(userId);

            return Ok(new Response() { Success = true, Data = user, Message = UserMessage.FOUND });
        }

    }
}
