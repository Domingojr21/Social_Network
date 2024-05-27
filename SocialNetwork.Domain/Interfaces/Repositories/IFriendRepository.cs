using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.InMemory.Repositories;

namespace SocialNetwork.Domain.Interfaces.Repositories
{
    public interface IFriendRepository : IGenericRepository<Friend>
    {
        List<Guid> GetFriends(Guid userId);
    }
}