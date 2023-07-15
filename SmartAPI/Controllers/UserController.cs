using Microsoft.AspNetCore.Mvc;
using SmartAPI.Models.Request;

namespace SmartAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        public UserController()
        {

        }

        [HttpPost]
        [Route("[action]")]
        //[ValidateAntiForgeryToken]
        public IActionResult Register(UserRegisterRequest userRegisterRequest)
        {
            try
            {
                return Ok();
            }
            catch
            {
                return Ok();
            }
        }

       
    }
}
