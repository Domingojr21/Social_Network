using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Application.Dtos.Queries
{
    /// <summary>
    /// DTO para seguir a un usuario.
    /// </summary>
    public class FollowUserQueryDto
    {
        /// <summary>
        /// Nombre de usuario del solicitante. Esta propiedad es requerida.
        /// </summary>
        public string UserNameOfUser { get; set; } = null!;

        /// <summary>
        /// Nombre de usuario del amigo a seguir. Esta propiedad es requerida.
        /// </summary>
         public string UserNameOfFriend { get; set; } = null!;
    }
}
