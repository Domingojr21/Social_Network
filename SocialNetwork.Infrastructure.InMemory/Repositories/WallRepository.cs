using System;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Interfaces.Repositories;
using SocialNetwork.Infrastructure.InMemory.Dictionaries;

namespace SocialNetwork.Infrastructure.InMemory.Repositories
{
    /// <summary>
    /// Repositorio de Muros donde se realizan las operacion de Manejo de Data
    /// </summary>
    public class WallRepository : GenericRepository<Wall>, IWallRepository
    {
        public WallRepository() : base(WallDictionary.Instance.Walls)
        {
        }

        public Wall? GetWallByUserId(Guid userId)
        {
            return GetById(userId);
        }

        public void AddPostToWall(Guid userId, Post post)
        {
            var wall = GetWallByUserId(userId);
            if (wall == null)
            {
                wall = new Wall { Id = userId, Posts = new List<Post>() };
                Add(wall);
            }
            wall.Posts.Add(post);
        }

        public List<Post> GetWallPosts(Guid userId)
        {
            var wall = GetWallByUserId(userId);
            return wall != null ? wall.Posts : new List<Post>();
        }
    }
}
