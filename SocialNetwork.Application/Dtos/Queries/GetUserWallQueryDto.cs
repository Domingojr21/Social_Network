using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Application.Dtos.Queries
{
    /// <summary>
    /// DTO para obtener el muro de las publicaciones de un usuario.
    /// </summary>
    public class GetUserWallQueryDto
    {
        /// <summary>
        /// Nombre de usuario. Esta propiedad es requerida.
        /// </summary>
        public string UserName { get; set; } = null!;
    }
}
