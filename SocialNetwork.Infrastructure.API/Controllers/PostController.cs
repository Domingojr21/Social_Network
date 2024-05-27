using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Dtos.Body;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Application.Wrappers;
using Swashbuckle.AspNetCore.Annotations;
using TaskMaster.WebApi.Controllers;

namespace SocialNetwork.Infrastructure.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [SwaggerTag("Post Manager")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostController : BaseApiController
    {
        private readonly IPostServices _postService;

        public PostController(IPostServices postService)
        {
            _postService = postService;
        }

        /// <summary>
        /// Publica un nuevo mensaje en el muro de un usuario.
        /// </summary>
        /// <param name="parameters">Los parámetros necesarios para publicar el mensaje.</param>
        /// <returns>El resultado de la operación de publicación del mensaje.</returns>
        /// <response code="201">Mensaje publicado exitosamente.</response>
        /// <response code="400">Solicitud inválida. Parámetros faltantes o incorrectos.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpPost("PostMessage")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostMessage([FromBody] PostDto parameters)
        {
            try
            {
                if (parameters == null || string.IsNullOrEmpty(parameters.UserName) || string.IsNullOrEmpty(parameters.Message))
                {
                    return BadRequest(new Response<string>("Invalid request"));
                }   
                var result = _postService.PostMessage(parameters.UserName, parameters.Message);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = $"{ex.Message}" });
            }
        }
    }
}
