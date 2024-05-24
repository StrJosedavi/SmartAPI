using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAPI.Application.Middleware.ResultException;
using SmartAPI.Business.Interface;
using SmartAPI.Business.Result;
using SmartAPI.Business.Services.DTO;
using SmartAPI.Business.Services.Messages;
using SmartAPI.Infrastructure.Data.Entity;
using SmartAPI.Models;

namespace SmartAPI.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper) {
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// Criação de usuário
        /// </summary>
        /// <param name="userRegisterRequest">Dados a ser enviado para registro de usuário.</param>
        /// <returns>Sucesso na criação de usuário</returns>

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserRegisterResult), 200)]
        [ProducesResponseType(typeof(HandleObjectResult), 400)]
        [ProducesResponseType(typeof(HandleObjectResult), 500)]
        public IActionResult Register([FromBody] UserRegisterRequest userRegisterRequest) 
        {
            var requestMapper = _mapper.Map<UserRegisterDTO>(userRegisterRequest);

            UserRegisterResult result = _userService.Register(requestMapper);

            return Ok(new { User = result, Message = UserMessage.CREATE });
        }

        /// <summary>
        /// Busca de usuário
        /// </summary>
        /// <param name="getUserByIdRequest">Dados de usuário para busca.</param>
        /// <returns>Sucesso na busca de usuário</returns>

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(HandleObjectResult), 404)]
        [ProducesResponseType(typeof(HandleObjectResult), 400)]
        [ProducesResponseType(typeof(HandleObjectResult), 500)]
        [Authorize]
        public IActionResult GetUser([FromQuery]GetUserByIdRequest getUserByIdRequest)
        {
            var requestMapper = _mapper.Map<GetUserByIdDTO>(getUserByIdRequest);

            User user = _userService.GetUser(requestMapper);

            return Ok(new { User = user, Message = UserMessage.FOUND });
        }

    }
}
