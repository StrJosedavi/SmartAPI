using SmartAPI.Controllers;
using SmartAPI.Data.Entity;
using SmartAPI.Services.Interface;
using Xunit;

namespace SmartAPI.Test.Controllers {
    public class UserControllerTests 
    {

        [Fact]
        public void GetUser() 
        {
            int userId = 1;

            var mockUserController = new Mock<UserController>();

            mockUserController.Setup(service => service.GetUser(userId)).Returns(new OkResult{});
        }
    }
}