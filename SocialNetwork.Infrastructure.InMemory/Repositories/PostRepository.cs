using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Interfaces.Repositories;
using SocialNetwork.Infrastructure.InMemory.Dictionaries;

namespace SocialNetwork.Infrastructure.InMemory.Repositories
{
    /// <summary>
    /// Repositorio de Post donde se realizan las operacion de Manejo de Data
    /// </summary>
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository() : base(PostDictionary.Instance.Posts)
        {
        }
    }
}
