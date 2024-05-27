

using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Application.Wrappers;
using SocialNetwork.Domain.Interfaces.Repositories;

namespace SocialNetwork.Application.Services
{
    /// <summary>
    /// Servicio que posee los casos de uso de Muros de Publicaciones 
    /// </summary>
    public class WallServices : IWallServices
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public WallServices(IFriendRepository friendRepository, IPostRepository postRepository, IUserRepository userRepository)
        {
            _friendRepository = friendRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public Response<dynamic> GetUserWall(string userName)
        {
            var user = _userRepository.GetUser(userName);

                        
            if(user == null)
            {
                return new Response<dynamic>($"El usuario {userName} no está registrado en la red Social");
            }

            var friends = _friendRepository.GetFriends(user.Id);
            var posts = _postRepository.GetAll()
                .Where(p => friends.Contains(p.UserId))
                .OrderBy(p => p.Date)
                .Select(p => $"“{p.Comment}” @{p.User?.UserName} @{p.Date:HH:mm}")
                .ToList();

            if( posts.Count < 1 )
            {
                return new Response<dynamic>($"El usuario {userName} no tiene publicaciones disponibles en el muro");
            }

            return new Response<dynamic>(posts);
        }
    }
}
