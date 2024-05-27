
using SocialNetwork.Application.Wrappers;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Application.Interfaces.Services
{
    public interface IWallServices
    {
        Response<dynamic> GetUserWall(string userName);
    }
}
