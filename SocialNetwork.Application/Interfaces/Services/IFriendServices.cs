using SocialNetwork.Application.Wrappers;

namespace SocialNetwork.Application.Interfaces.Services
{
    public interface IFriendServices
    {
        Response<string> FollowUser(string userNameOfUser, string userNameOfFriend);
    }
}