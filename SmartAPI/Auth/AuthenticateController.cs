using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAPI.Auth.Service;

namespace SmartAPI.Auth {
    [Route("[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase {

        private readonly IAuthenticateService _authenticationService;

        public AuthenticateController(IAuthenticateService authenticationService) {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Geração de token de autenticação
        /// </summary>
        /// <returns>Token de autenticação</returns>
        [AllowAnonymous]
        [Route("[action]")]
        [HttpGet]
        public IActionResult GenerateToken() 
        {
            var token = _authenticationService.GenerateJwtToken();
            return Ok(new { Token = token });
        }

       
    }
}
