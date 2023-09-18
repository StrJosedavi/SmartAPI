using SmartAPI.Controllers;
using SmartAPI.Data.Entity;
using SmartAPI.Services.Interface;
using SmartAPI.Services.Messages;
using System.Security.Cryptography;
using Xunit;

namespace SmartAPI.Test.Controllers {
    public class UserControllerTests {

        [Fact]
        public void GetUser() 
        {
            Random random = new Random();
            long UserId = random.NextInt64(1, long.MaxValue);

            var service = new Mock<IUserService>();
            service.Setup(service => service.GetUser(UserId)).Returns(new User { Id = UserId, IsAdmin = false });

            var controller = new UserController(service.Object);
            var result = controller.GetUser(UserId);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}