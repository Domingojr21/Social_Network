using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SocialNetwork.Application.Dtos.Queries;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Application.Wrappers;
using SocialNetwork.Infrastructure.API.Controllers;
using Xunit;

namespace SocialNetwork.Infrastructure.Test
{
    public class FriendControllerTestValidation
    {
        private readonly Mock<IFriendServices> _friendServiceMock;
        private readonly FriendController _controller;

        public FriendControllerTestValidation()
        {
            _friendServiceMock = new Mock<IFriendServices>();
            _controller = new FriendController(_friendServiceMock.Object);
        }

        [Fact]
        public void FollowUser_ReturnsOkResult_WithValidParameters()
        {
            // Arrange
            var parameters = new FollowUserQueryDto
            {
                UserNameOfUser = "Marcos",
                UserNameOfFriend = "Lucas"
            };
            _friendServiceMock.Setup(service => service.FollowUser(parameters.UserNameOfUser, parameters.UserNameOfFriend))
                .Returns(new Response<string>("Marcos empezó a seguir a Lucas."));

            // Act
            var result = _controller.FollowUser(parameters) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            var response = Assert.IsType<Response<string>>(result.Value);
            Assert.Equal("Marcos empezó a seguir a Lucas.", response.Message);
        }

        [Fact]
        public void FollowUser_ReturnsInternalServerError_OnException()
        {
            // Arrange
            var parameters = new FollowUserQueryDto
            {
                UserNameOfUser = "Marcos",
                UserNameOfFriend = "Lucas"
            };
            _friendServiceMock.Setup(service => service.FollowUser(parameters.UserNameOfUser, parameters.UserNameOfFriend))
                .Throws(new Exception("Error interno del servidor"));

            // Act
            var result = _controller.FollowUser(parameters) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
            var errorResponse = Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public void FollowUser_ReturnsOkResult_ForSameUserNames()
        {
            // Arrange
            var parameters = new FollowUserQueryDto
            {
                UserNameOfUser = "Marcos",
                UserNameOfFriend = "Marcos"
            };
            _friendServiceMock.Setup(service => service.FollowUser(parameters.UserNameOfUser, parameters.UserNameOfFriend))
                .Returns(new Response<string>($"{parameters.UserNameOfUser} y {parameters.UserNameOfFriend} son el mismo Usuario"));

            // Act
            var result = _controller.FollowUser(parameters) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            var response = Assert.IsType<Response<string>>(result.Value);
            Assert.False(response.Succeeded);
            Assert.Equal("Marcos y Marcos son el mismo Usuario", response.Message);
        }

        [Fact]
        public void FollowUser_ReturnsOkResult_ForNonExistentUser()
        {
            // Arrange
            var parameters = new FollowUserQueryDto
            {
                UserNameOfUser = "Jose",
                UserNameOfFriend = "Lucas"
            };
            _friendServiceMock.Setup(service => service.FollowUser(parameters.UserNameOfUser, parameters.UserNameOfFriend))
                .Returns(new Response<string>($"No se encontró ningún usuario {parameters.UserNameOfUser}"));

            // Act
            var result = _controller.FollowUser(parameters) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            var response = Assert.IsType<Response<string>>(result.Value);
            Assert.False(response.Succeeded);
            Assert.Equal($"No se encontró ningún usuario {parameters.UserNameOfUser}", response.Message);
        }

        [Fact]
        public void FollowUser_ReturnsOkResult_ForNonExistentFriend()
        {
            // Arrange
            var parameters = new FollowUserQueryDto
            {
                UserNameOfUser = "Marcos",
                UserNameOfFriend = "Maria"
            };
            _friendServiceMock.Setup(service => service.FollowUser(parameters.UserNameOfUser, parameters.UserNameOfFriend))
                .Returns(new Response<string>($"No se encontró ningún usuario {parameters.UserNameOfFriend}"));

            // Act
            var result = _controller.FollowUser(parameters) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            var response = Assert.IsType<Response<string>>(result.Value);
            Assert.False(response.Succeeded);
            Assert.Equal($"No se encontró ningún usuario {parameters.UserNameOfFriend}", response.Message);
        }

        [Fact]
        public void FollowUser_ReturnsOkResult_WhenAlreadyFollowing()
        {
            // Arrange
            var parameters = new FollowUserQueryDto
            {
                UserNameOfUser = "Marcos",
                UserNameOfFriend = "Lucas"
            };
            _friendServiceMock.Setup(service => service.FollowUser(parameters.UserNameOfUser, parameters.UserNameOfFriend))
                .Returns(new Response<string>($"{parameters.UserNameOfUser} ya sigue a {parameters.UserNameOfFriend}."));

            // Act
            var result = _controller.FollowUser(parameters) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            var response = Assert.IsType<Response<string>>(result.Value);
            Assert.False(response.Succeeded);
            Assert.Equal($"{parameters.UserNameOfUser} ya sigue a {parameters.UserNameOfFriend}.", response.Message);
        }
    }
}
