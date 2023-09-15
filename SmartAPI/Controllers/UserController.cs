using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAPI.Data.Entity;
using SmartAPI.Models.Request;
using SmartAPI.Models.Result;
using SmartAPI.Services.Interface;
using SmartAPI.Services.Messages;
using System.ComponentModel.DataAnnotations;

namespace SmartAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
           _userService = userService;
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
            _userService.Register(userRegisterRequest);

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
        public IActionResult GetUser([FromQuery][Required(ErrorMessage = "Necessário UserId")][Range(1, int.MaxValue)] long userId)
        {
            User user = _userService.GetUser(userId);

            return Ok(new Response() { Success = true, Data = user, Message = UserMessage.FOUND });
        }

    }
}
