namespace SmartAPI.Test.Controllers {
    public class UserControllerTests 
    {

        [Fact]
        public void GetUser_ValidUserId() 
        {
           /* int userId = 1;

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

            Assert.NotNull(user);
            Assert.Equal(userId, user.Id);*/
        }


        [Fact]
        public void GetUser_InvalidUserId() 
        {
            /*int userId = 0;

            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.GetUser(userId))
                          .Throws(new UserException(System.Net.HttpStatusCode.BadRequest));
            var controller = new UserController(mockUserService.Object);

            // Act
            var result = controller.GetUser(userId);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);*/
        }

        [Fact]
        public void GetUser_NotFoundUserId() 
        {
            /*int userId = 1;
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.GetUser(userId))
                          .Throws(new UserException(System.Net.HttpStatusCode.NotFound));
            var controller = new UserController(mockUserService.Object);

            // Act
            var result = controller.GetUser(userId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);*/
        }
    }
}