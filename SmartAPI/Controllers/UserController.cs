using Microsoft.AspNetCore.Mvc;
using SmartAPI.Data.Entity;
using SmartAPI.Models.Request;
using SmartAPI.Models.Result;
using SmartAPI.Services;
using SmartAPI.Services.Exceptions.UserExceptions;
using SmartAPI.Services.Interface;

namespace SmartAPI.Controllers
{
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
        [ProducesResponseType(200, Type = typeof(Response))]    
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Register(UserRegisterRequest userRegisterRequest)
        {
            try
            {
                _userService.Register(userRegisterRequest);
                return Ok(new Response(){ Success = true, Data = null, Message = "Usuário registrado com sucesso" });
            }
            catch
            {
                return BadRequest(new Response() { Success = false, Data = null, Message = "Falha na criação de usuário" });
            }
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
        public IActionResult GetUser(long userId)
        {
            try
            {   
                User user = _userService.GetUser(userId);

                return Ok(new Response() { Success = true, Data = user, Message = "Usuário encontrado com sucesso." });
            }
            catch(UserException ex)
            {
                return UserException.HandleCustomException(ex);
            }
        }

    }
}
