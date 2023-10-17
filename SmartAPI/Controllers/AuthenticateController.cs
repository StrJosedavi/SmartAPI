using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartAPI.Application.Models.Request;
using SmartAPI.Business.Interface;
using SmartAPI.Infrastructure.Data.Entity;

namespace SmartAPI.Application.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {

        private readonly IAuthenticateService _authenticationService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AuthenticateController(IAuthenticateService authenticationService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _authenticationService = authenticationService;
        }

      /*  /// <summary>
        /// Geração de token de autenticação
        /// </summary>
        /// <returns>Token de autenticação</returns>
        [AllowAnonymous]
        [Route("[action]")]
        [HttpGet]
        public IActionResult GenerateToken(User user)
        {
            var token = _authenticationService.GenerateJwtToken(user);
            return Ok(token);
        }*/


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest LoginRequest) 
        {
            var user = await _userManager.FindByNameAsync(LoginRequest.UserName);

            if (user == null || !await _userManager.CheckPasswordAsync(user, LoginRequest.Password)) {
                return Unauthorized("Credenciais inválidas.");
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, LoginRequest.Password, false, false);

            if (!signInResult.Succeeded) {
                return Unauthorized("Falha na autenticação.");
            }

            var token = _authenticationService.GenerateJwtToken(user); // Use sua classe de serviço JWT para gerar um token JWT personalizado

            return Ok(new { Token = token });
        }
    }
}
