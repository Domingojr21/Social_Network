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
    [SwaggerTag("User Manager")]
    public class UserController : BaseApiController
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        /// <summary>
        /// Crea un nuevo usuario en la red social.
        /// </summary>
        /// <param name="user">El objeto que contiene la información del usuario a crear.</param>
        /// <returns>Retorna un objeto de respuesta que indica el éxito o fracaso de la operación.</returns>
        /// <response code="201">Usuario creado exitosamente.</response>
        /// <response code="400">Solicitud inválida. El objeto del usuario es nulo o el nombre de usuario está vacío.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Add([FromBody] UserDto user)
        {
            try
            {
                if (user == null || string.IsNullOrEmpty(user.UserName))
                {
                    return BadRequest(new Response<int>("Invalid request"));
                }

                var result = _userServices.AddUser(user);
                return CreatedAtAction(nameof(Add), new { id = result }, result); 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = $"{ex.Message}" });
            }
        }
    }
}
