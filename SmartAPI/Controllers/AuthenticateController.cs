using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAPI.Business.Interface;

namespace SmartAPI.Application.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {

        private readonly IAuthenticateService _authenticationService;

        public AuthenticateController(IAuthenticateService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Geração de token de autenticação
        /// </summary>
        /// <returns>Token de autenticação</returns>
        [AllowAnonymous]
        [Route("[action]")]
        [HttpPost]
        public IActionResult GenerateToken()
        {
            var token = _authenticationService.GenerateJwtToken();
            return Ok(token);
        }


    }
}
