using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Application.Wrappers;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Interfaces.Repositories;

namespace SocialNetwork.Application.Services
{
    /// <summary>
    /// Servicio que posee los casos de uso de Publicaciones
    /// </summary>
    public class PostServices : IPostServices
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public PostServices(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public Response<string> PostMessage(string userName, string message)
        {

            var user = _userRepository.GetUser(userName);
            
            if(user == null)
            {
                return new Response<string>($"{userName} no está registrado en el sistema por esta razón no puede crear Post");
            }

            var post = new Post
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Comment = message,
                UserId = user.Id,
                User = user
            };
            _postRepository.Add(post);
            return new Response<string>($"{user.UserName} posted -> “{message}” @{post.Date:HH:mm}");
        }



    }
}
