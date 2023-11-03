using AutoMapper;
using SmartAPI.Application.Controllers;
using SmartAPI.Application.Models.Request;
using SmartAPI.Business.Interface;
using SmartAPI.Business.Services.DTO;
using SmartAPI.Infrastructure.Data.Entity;

namespace SmartAPI.Test.Controllers {
    public class UserControllerTests 
    {

        [Fact]
        public void GetUser_ValidUserId() 
        {
          /* string userId = Guid.NewGuid().ToString();

            //Arrange
            var mockUserService = new Mock<IUserService>();
            var mockMapper = new Mock<IMapper>();

            // Act
            var controller = new UserController(mockUserService.Object, mockMapper.Object);
            var request = new GetUserByIdRequest() { UserId = userId };

            var DTO = mockMapper.Object.Map<GetUserByIdDTO>(request);

            mockUserService.Setup(service => service.GetUser(DTO)).Returns(new User { Id = userId, Status = 0, UserName = "Teste"});

            // Act
            var result = controller.GetUser(request);

            // Assert
            dynamic okResult = Assert.IsType<UserController>(result);
            var user = Assert.IsType<User>(okResult.Value.Data);*/

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