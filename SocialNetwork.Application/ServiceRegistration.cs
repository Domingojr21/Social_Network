using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Application.Services;

namespace SocialNetwork.Application
{
    /// <summary>
    /// Decorator de la capa de Application para extender la funcionalidad del program para inyectar la Dependencias 
    /// </summary>
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region Services
            services.AddTransient<IWallServices, WallServices>();
            services.AddTransient<IPostServices, PostServices>();
            services.AddTransient<IFriendServices, FriendServices>();
            services.AddTransient<IUserServices, UserServices>();
            #endregion
        }
    }
}
