

namespace SocialNetwork.Application.Dtos.Body
{
    /// <summary>
    /// DTO para el cuerpo de una publicación.
    /// </summary>
    public class PostDto
    {
        /// <summary>
        /// Nombre de usuario. Esta propiedad es requerida.
        /// </summary>
        public string UserName { get; set; } = null!;

        /// <summary>
        /// Mensaje de la publicación. Esta propiedad es requerida.
        /// </summary>
        public string Message { get; set; } = null!;
    }
}
