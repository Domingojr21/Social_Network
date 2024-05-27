
namespace SocialNetwork.Domain.Entities
{
    /// <summary>
    /// Entidad que Representa a los Amigos en la Red Social
    /// </summary>
    public class Friend : BaseEntity
    {
        public User? User { get; set; }
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
    }
}
