using SocialNetwork.Application.Dtos.Body;
using SocialNetwork.Application.Wrappers;

namespace SocialNetwork.Application.Interfaces.Services
{
    public interface IUserServices
    {
        Response<string> AddUser(UserDto userDto);
    }
}