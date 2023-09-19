using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAPI.Data.Entity;
using SmartAPI.Middleware.ResultException;
using SmartAPI.Models.Request;
using SmartAPI.Models.Result;
using SmartAPI.Services.Interface;
using SmartAPI.Services.Messages;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

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
        [ProducesResponseType(404, Type = typeof(HandleExceptionObjectResult))]
        [ProducesResponseType(400, Type = typeof(HandleExceptionObjectResult))]
        [ProducesResponseType(500, Type = typeof(HandleExceptionObjectResult))]
        public IActionResult Register(UserRegisterRequest userRegisterRequest)
        {
            //_userService.Register(userRegisterRequest);

            return Ok(new Response(){ Success = true, Data = null, Message = UserMessage.Create});
        }

        /// <summary>
        /// Busca de usuário
        /// </summary>
        /// <param name="getUserByIdRequest">Dados de usuário para busca.</param>
        /// <returns>Sucesso na busca de usuário</returns>

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(200, Type = typeof(Response))]
        [ProducesResponseType(404, Type = typeof(HandleExceptionObjectResult))]
        [ProducesResponseType(400, Type = typeof(HandleExceptionObjectResult))]
        [ProducesResponseType(500, Type = typeof(HandleExceptionObjectResult))]
        [Authorize]
        public IActionResult GetUser([FromQuery] GetUserByIdRequest getUserByIdRequest)
        {
            User user = _userService.GetUser(getUserByIdRequest.UserId);

            return Ok(new Response() { Success = true, Data = user, Message = UserMessage.Found });
        }

    }
}
