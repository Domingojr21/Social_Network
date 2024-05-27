using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Interfaces.Repositories;

namespace SocialNetwork.Infrastructure.InMemory.Seeds
{
    /// <summary>
    /// Clase que se encarga de crear los usuarios por Defecto al correr el programa
    /// </summary>
    public static class UsersSeed 
    {
        public static void CreateDefaultUsers(IUserRepository userRepository)
        {
            var user1 = new User { Id = Guid.NewGuid(), UserName = "Alfonso" };
            var user2 = new User { Id = Guid.NewGuid(), UserName = "Ivan" };
            var user3 = new User { Id = Guid.NewGuid(), UserName = "Alicia" };

            userRepository.Add(user1);
            userRepository.Add(user2);
            userRepository.Add(user3);
        }
    }
}
