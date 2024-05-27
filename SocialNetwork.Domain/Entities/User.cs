

namespace SocialNetwork.Domain.Entities
{
    /// <summary>
    /// Entidad que Representa los Usuarios de la Red Social
    /// </summary>
    public class User : BaseEntity
    {
        public string UserName { get; set; } = null!;
       public List<Friend>? Friends { get; set; }
    }
}
