

using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Interfaces.Repositories;

namespace SocialNetwork.Infrastructure.InMemory.Seeds
{
    /// <summary>
    /// Clase que se encarga de crear las publicaciones por Defecto al correr el programa
    /// </summary>
    public static class PostsSeed
    {
       
        public static void CreateDefaultPosts(IUserRepository userRepository, IPostRepository postRepository)
        {
            var today = DateTime.Today;

            var user1 = userRepository.GetUser("Alfonso");
            var user2 = userRepository.GetUser("Ivan");

            if (user1 != null && user2 != null)
            {
                var post1 = new Post { Id = Guid.NewGuid(), Date = today.AddHours(8).AddMinutes(10), Comment = "Hoy puede ser un gran día", UserId = user2.Id, User = user2 };
                postRepository.Add(post1);

                var post2 = new Post { Id = Guid.NewGuid(), Date = today.AddHours(10).AddMinutes(30), Comment = "Hola mundo", UserId = user1.Id, User = user1 };
                postRepository.Add(post2);

                var post3 = new Post { Id = Guid.NewGuid(), Date = today.AddHours(20).AddMinutes(10), Comment = "Para casa ya, media jornada, 12h", UserId = user2.Id, User = user2 };
                postRepository.Add(post3);

                var post4 = new Post { Id = Guid.NewGuid(), Date = today.AddHours(20).AddMinutes(30), Comment = "Adiós mundo cruel", UserId = user1.Id, User = user1 };
                postRepository.Add(post4);
            }
        }
    }
}
