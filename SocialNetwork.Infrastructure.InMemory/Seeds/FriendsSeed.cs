using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Interfaces.Repositories;

namespace SocialNetwork.Infrastructure.InMemory.Seeds
{
    /// <summary>
    /// Clase que se encarga de crear los amigos por Defecto al correr el programa
    /// </summary>
    public static class FriendsSeed 
    {
        public static void CreateDefaultFriends(IUserRepository userRepository, IFriendRepository friendRepository)
        {
            var user1 = userRepository.GetUser("Alfonso");
            var user2 = userRepository.GetUser("Ivan");
            var user3 = userRepository.GetUser("Alicia");

            if (user1 != null && user2 != null)
            {
                var friend1 = new Friend { Id = Guid.NewGuid(), UserId = user3.Id, FriendId = user2.Id };
                friendRepository.Add(friend1);
            }

            if (user1 != null && user3 != null)
            {
                var friend2 = new Friend { Id = Guid.NewGuid(), UserId = user3.Id, FriendId = user1.Id };
                friendRepository.Add(friend2);
            }
        }
    }
}
