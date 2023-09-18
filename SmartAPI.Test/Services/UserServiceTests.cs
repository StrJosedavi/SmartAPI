using SmartAPI.Controllers;
using SmartAPI.Data.Entity;
using SmartAPI.Services.Interface;
using Xunit;

namespace SmartAPI.Test.Controllers {
    public class UserServiceTests 
    {

       [Fact]
        public void GetUser_ValidUserId() 
        {
            int userId = 1;

            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.GetUser(userId))
                          .Returns(new User { Id = userId, IsAdmin = false });
            var controller = new UserController(mockUserService.Object);

            // Act
            dynamic result = controller.GetUser(userId);
            var user = result.Value.Data;

            // Assert
            Assert.IsType<User>(user);
            Assert.NotNull(user);
            Assert.Equal(userId, user.Id);
        }


        [Fact]
        public void GetUser_InvalidUserId() 
        {
            
        }

        [Fact]
        public void GetUser_NotFoundUserId() 
        {
           /* int userId = 0;

            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.GetUser(1)).Throws<Exception>();

            var controller = new UserController(mockUserService.Object);

            // Act
            dynamic result = controller.GetUser(userId);
            var user = result.Value.Data;*/
        }
    }
}