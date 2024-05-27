using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SocialNetwork.Application.Dtos.Queries;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Application.Wrappers;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.API.Controllers;
using System;
using System.Collections.Generic;
using Xunit;

namespace SocialNetwork.Test.UnitTest
{
    public class WallControllerTestValidation
    {
        private readonly Mock<IWallServices> _wallServicesMock;
        private readonly WallController _controller;

        public WallControllerTestValidation()
        {
            _wallServicesMock = new Mock<IWallServices>();
            _controller = new WallController(_wallServicesMock.Object);
        }

        [Fact]
        public void GetUserWall_ReturnsOkResult_WithValidParameters()
        {
            // Arrange
            var userName = "Alfonso";
            var wallPosts = new List<Post>
            {
                new Post { Id = Guid.NewGuid(), Comment = "Hola mundo", Date = DateTime.Now },
                new Post { Id = Guid.NewGuid(), Comment = "Otro post", Date = DateTime.Now.AddMinutes(-10) }
            };
            _wallServicesMock.Setup(service => service.GetUserWall(userName)).Returns(new Response<dynamic>(wallPosts));
            var queryDto = new GetUserWallQueryDto { UserName = userName };

            // Act
            var result = _controller.GetUserWall(queryDto) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public void GetUserWall_ReturnsInternalServerError_OnException()
        {
            // Arrange
            var userName = "Alfonso";
            _wallServicesMock.Setup(service => service.GetUserWall(userName)).Throws(new Exception("Error interno del servidor"));
            var queryDto = new GetUserWallQueryDto { UserName = userName };

            // Act
            var result = _controller.GetUserWall(queryDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
            var errorResponse = Assert.IsType<ObjectResult>(result);
        }
        
    }
}
