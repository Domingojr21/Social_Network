using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Dtos.Queries;
using SocialNetwork.Application.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;
using TaskMaster.WebApi.Controllers;

namespace SocialNetwork.Infrastructure.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [SwaggerTag("Friend Manager")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FriendController : BaseApiController
    {
        private readonly IFriendServices _friendService;

        public FriendController(IFriendServices friendService)
        {
            _friendService = friendService;
        }

        /// <summary>
        /// Permite a un usuario seguir a otro usuario.
        /// </summary>
        /// <param name="parameters">Parámetros necesarios para seguir a un usuario.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        /// <response code="200">Operación exitosa.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet("FollowUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult FollowUser([FromQuery] FollowUserQueryDto parameters)
        {
            try
            {
                var message = _friendService.FollowUser(parameters.UserNameOfUser, parameters.UserNameOfFriend);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = $"{ex.Message}" });
            }
        }
    }
}
