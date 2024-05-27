using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Application.Wrappers;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Interfaces.Repositories;

namespace SocialNetwork.Application.Services
{
    /// <summary>
    /// Servicio que posee los casos de uso de Amigos
    /// </summary>
    public class FriendServices : IFriendServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IFriendRepository _friendRepository;

        public FriendServices(IUserRepository userRepository, IFriendRepository friendRepository)
        {
            _userRepository = userRepository;
            _friendRepository = friendRepository;
        }

        public Response<string> FollowUser(string userNameOfUser, string userNameOfFriend)
        {
            var user = _userRepository.GetUser(userNameOfUser.Replace("@", ""));
            if (user == null)
            {
                return new Response<string>($"No se encontró ningún usuario {userNameOfUser}");
            }

            var targetUser = _userRepository.GetUser(userNameOfFriend.Replace("@", ""));
            if (targetUser == null)
            {
                return new Response<string>($"No se encontró ningún usuario {userNameOfFriend}");
            }
            if (userNameOfUser == userNameOfFriend)
            {
                return new Response<string>($"{userNameOfUser} y {userNameOfFriend} son el mismo Usuario");
            }

            if (_friendRepository.GetFriends(user.Id).Contains(targetUser.Id))
            {
               return new Response<string>($"{user.UserName} ya sigue a {targetUser.UserName}.");
            }

            var friend = new Friend
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                FriendId = targetUser.Id
            };
            _friendRepository.Add(friend);
            return new Response<string>($"{user.UserName} empezó a seguir a {targetUser.UserName}.");
        }
    }
}
