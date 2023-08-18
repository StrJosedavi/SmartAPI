using Microsoft.AspNetCore.Mvc;
using SmartAPI.Models.Result;
using System.Net;

namespace SmartAPI.Services.Exceptions.UserExceptions
{
    public class UserException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public UserException(HttpStatusCode statusCode) {
            StatusCode = statusCode;
        }

        public static IActionResult HandleCustomException(UserException ex) {

            switch (ex.StatusCode) {
                case HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(new Response { Success = false, Data = null, Message = "Usuário não Encontrado" });
                case HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(new Response { Success = false, Data = null, Message = "Ocorreu um erro ao tentar processar a solicitação" });
                default:
                    return new StatusCodeResult(500);
            }
        }
    }
}
