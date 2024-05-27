using System.Linq;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Interfaces.Repositories;
using SocialNetwork.Infrastructure.InMemory.Dictionaries;

namespace SocialNetwork.Infrastructure.InMemory.Repositories
{
    /// <summary>
    /// Repositorio de Usuarios donde se realizan las operacion de Manejo de Data
    /// </summary>
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository() : base(UsersDictionary.Instance.Users)
        {
        }

        public User? GetUser(string userName)
        {
            return GetAll().FirstOrDefault(u => u.UserName == userName);
        }
    }
}
