using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.InMemory.Repositories;

namespace SocialNetwork.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User? GetUser(string userName);
    }
}