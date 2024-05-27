
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Interfaces.Repositories;
using SocialNetwork.Infrastructure.InMemory.Dictionaries;

namespace SocialNetwork.Infrastructure.InMemory.Repositories
{
    /// <summary>
    /// Repositorio de Amigos donde se realizan las operacion de Manejo de Data
    /// </summary>
    public class FriendRepository : GenericRepository<Friend>, IFriendRepository
    {
        public FriendRepository() : base(FriendDictionary.Instance.Friends)
        {
        }

        public List<Guid> GetFriends(Guid userId)
        {
            return GetAll().Where(f => f.UserId == userId).Select(f => f.FriendId).ToList();
        }
    }
}
