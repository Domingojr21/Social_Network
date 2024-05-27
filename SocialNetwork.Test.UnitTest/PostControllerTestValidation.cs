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
    public class PostControllerTestValidation
    {
        private readonly Mock<IPostServices> _postServiceMock;
        private readonly PostController _controller;

        public PostControllerTestValidation()
        {
            _postServiceMock = new Mock<IPostServices>();
            _controller = new PostController(_postServiceMock.Object);
        }

        [Fact]
        public void PostMessage_ReturnsCreatedResult_WithValidParameters()
        {
            // Arrange
            var parameters = new PostDto
            {
                UserName = "User1",
                Message = "Hello World"
            };
            _postServiceMock.Setup(service => service.PostMessage(parameters.UserName, parameters.Message))
                .Returns(new Response<string>("Mensaje publicado exitosamente."));

            // Act
            var result = _controller.PostMessage(parameters) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result.StatusCode);
            var response = Assert.IsType<Response<string>>(result.Value);
            Assert.Equal("Mensaje publicado exitosamente.", response.Message);
        }

        [Fact]
        public void PostMessage_ReturnsBadRequestResult_WithInvalidParameters()
        {
            // Arrange
            PostDto parameters = null;

            // Act
            var result = _controller.PostMessage(parameters) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            var response = Assert.IsType<Response<string>>(result.Value);
            Assert.Equal("Invalid request", response.Message);
        }

        [Fact]
        public void PostMessage_ReturnsInternalServerError_OnException()
        {
            // Arrange
            var parameters = new PostDto
            {
                UserName = "User1",
                Message = "Hello World"
            };
            _postServiceMock.Setup(service => service.PostMessage(parameters.UserName, parameters.Message))
                .Throws(new Exception("Error interno del servidor"));

            // Act
            var result = _controller.PostMessage(parameters) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
        }
    }
}
