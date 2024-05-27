using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Dtos.Queries;
using SocialNetwork.Application.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;
using TaskMaster.WebApi.Controllers;

namespace SocialNetwork.Infrastructure.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [SwaggerTag("Wall Manager")]
    public class WallController : BaseApiController
    {
        private readonly IWallServices _wallServices;

        public WallController(IWallServices wallServices)
        {
            _wallServices = wallServices;
        }

        /// <summary>
        /// Obtiene el muro de publicaciones de los amigos de un usuario.
        /// </summary>
        /// <param name="dto">Los parámetros para obtener el muro del usuario.</param>
        /// <returns>Una lista de publicaciones de los amigos del usuario.</returns>
        /// <response code="200">Operación exitosa. Devuelve la lista de publicaciones.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet("GetUserWall")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetUserWall([FromQuery] GetUserWallQueryDto dto)
        {
            try
            {
                var wall = _wallServices.GetUserWall(dto.UserName);
                return Ok(wall);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = $"{ex.Message}" });
            }
        }
    }
}
