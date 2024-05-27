

namespace SocialNetwork.Domain.Entities
{
    /// <summary>
    /// Entidad que Representa el muro de las publicaciones de los amigos de los usuarios
    /// </summary>
    public class Wall : BaseEntity
    {
        public List<Post>? Posts { get; set; }
    }
}
