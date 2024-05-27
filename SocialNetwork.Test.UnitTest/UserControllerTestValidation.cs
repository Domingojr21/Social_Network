using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SocialNetwork.Application.Dtos.Body;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Application.Wrappers;
using SocialNetwork.Infrastructure.API.Controllers;
using Xunit;

namespace SocialNetwork.Test.UnitTest
{
    public class UserControllerTestValidation
    {
        private readonly Mock<IUserServices> _userServiceMock;
        private readonly UserController _controller;

        public UserControllerTestValidation()
        {
            _userServiceMock = new Mock<IUserServices>();
            _controller = new UserController(_userServiceMock.Object);
        }

        [Fact]
        public void AddUser_ReturnsCreatedResult_WithValidParameters()
        {
            // Arrange
            var userDto = new UserDto { UserName = "Angelica" };
            _userServiceMock.Setup(service => service.AddUser(userDto))
                .Returns(new Response<string>("Angelica fue creado exitosamente"));

            // Act
            var result = _controller.Add(userDto) as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result.StatusCode);
            var response = Assert.IsType<Response<string>>(result.Value);
            Assert.Equal("Angelica fue creado exitosamente", response.Message);
        }

        [Fact]
        public void AddUser_ReturnsBadRequestResult_WithNullUser()
        {
            // Arrange
            UserDto userDto = null;

            // Act
            var result = _controller.Add(userDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            var response = Assert.IsType<Response<int>>(result.Value);
            Assert.False(response.Succeeded);
            Assert.Equal("Invalid request", response.Message);
        }

        [Fact]
        public void AddUser_ReturnsBadRequestResult_WithEmptyUserName()
        {
            // Arrange
            var userDto = new UserDto { UserName = "" };

            // Act
            var result = _controller.Add(userDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            var response = Assert.IsType<Response<int>>(result.Value);
            Assert.False(response.Succeeded);
            Assert.Equal("Invalid request", response.Message);
        }

        [Fact]
        public void AddUser_ReturnsConflictResult_WhenUserAlreadyExists()
        {
            // Arrange
            var userDto = new UserDto { UserName = "Angelica" };
            _userServiceMock.Setup(service => service.AddUser(userDto))
                .Returns(new Response<string>("Angelica ya existe en el sistema"));

            // Act
            var result = _controller.Add(userDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result.StatusCode);
            var response = Assert.IsType<Response<string>>(result.Value);
            Assert.False(response.Succeeded);
            Assert.Equal("Angelica ya existe en el sistema", response.Message);
        }

        [Fact]
        public void AddUser_ReturnsInternalServerError_OnException()
        {
            // Arrange
            var userDto = new UserDto { UserName = "Angelica" };
            _userServiceMock.Setup(service => service.AddUser(userDto))
                .Throws(new Exception("Error interno del servidor"));

            // Act
            var result = _controller.Add(userDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
            var errorResponse = Assert.IsType<ObjectResult>(result);
        }
    }
}
