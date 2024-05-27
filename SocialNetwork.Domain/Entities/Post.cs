
namespace SocialNetwork.Domain.Entities
{
    /// <summary>
    /// Entidad que Representa las publicaciones realizadas
    /// </summary>
    public class Post : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Comment { get; set; } = null!;
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
