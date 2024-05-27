using SocialNetwork.Application.Wrappers;

namespace SocialNetwork.Application.Interfaces.Services
{
    public interface IPostServices
    {
        Response<string> PostMessage(string userName, string message);
    }
}