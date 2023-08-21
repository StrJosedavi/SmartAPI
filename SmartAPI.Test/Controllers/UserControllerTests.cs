using SmartAPI.Controllers;
using SmartAPI.Data.Entity;
using SmartAPI.Services.Interface;

namespace SmartAPI.Test.Controllers
{
    public class UserControllerTests 
    {
        [Fact]
        public void GetUser_Returns()
        {
            int userId = 1;

            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.GetUser(userId))
                          .Returns(new User { Id = userId, IsAdmin = false });
            var controller = new UserController(mockUserService.Object);

            // Act
            var result = controller.GetUser(userId);

            // Assert
            dynamic okResult = Assert.IsType<OkObjectResult>(result);
            var user = Assert.IsType<User>(okResult.Value.Data);
            Assert.Equal(userId, user.Id);
        }
    }
}