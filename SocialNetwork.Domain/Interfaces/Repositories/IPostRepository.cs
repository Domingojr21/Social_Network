using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.InMemory.Repositories;

namespace SocialNetwork.Domain.Interfaces.Repositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {
    }
}