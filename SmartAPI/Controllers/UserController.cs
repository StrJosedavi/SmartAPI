﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAPI.Application.Models.Request;
using SmartAPI.Business.Interface;
using SmartAPI.Business.Services.DTO;
using SmartAPI.Business.Services.Messages;
using SmartAPI.Infrastructure.Data.Entity;
using System.Security.Claims;

namespace SmartAPI.Application.Controllers {
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
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]UserRegisterRequest userRegisterRequest)
        {
            var RequestMapper = _mapper.Map<UserRegisterDTO>(userRegisterRequest);
            User user = await _userService.Register(RequestMapper);
            return Ok(new { Success = true, User = user, Message = UserMessage.CREATE});
        }

        /// <summary>
        /// Busca de usuário
        /// </summary>
        /// <param name="getUserByIdRequest">Dados de usuário para busca.</param>
        /// <returns>Sucesso na busca de usuário</returns>

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        [Authorize(Policy = "Master")]
        public IActionResult GetUser([FromQuery]GetUserByIdRequest getUserByIdRequest)
        {
            var RequestMapper = _mapper.Map<GetUserByIdDTO>(getUserByIdRequest);
            User user = _userService.GetUser(RequestMapper);
            return Ok(new { Success = true, User = user, Message = UserMessage.FOUND });
        }

    }
}
