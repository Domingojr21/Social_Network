using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.InMemory.Repositories;

namespace SocialNetwork.Domain.Interfaces.Repositories
{
    public interface IWallRepository : IGenericRepository<Wall>
    {
        Wall? GetWallByUserId(Guid userId);
        void AddPostToWall(Guid userId, Post post);
        List<Post> GetWallPosts(Guid userId);
    }
}