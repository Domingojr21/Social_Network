

using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Domain.Interfaces.Repositories;
using SocialNetwork.Infrastructure.InMemory.Repositories;

namespace SocialNetwork.Infrastructure.InMemory
{
    /// <summary>
    /// Decorator de la capa de InMemory para extender la funcionalidad del program para inyectar la Dependencias 
    /// </summary>
    public static class ServiceRegistration
    {
        public static void AddInMemoryLayer(this IServiceCollection services)
        {
            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IWallRepository, WallRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IFriendRepository, FriendRepository>();
            #endregion
        }
    }
}
