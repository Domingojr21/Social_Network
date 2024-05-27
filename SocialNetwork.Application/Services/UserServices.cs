

using SocialNetwork.Application.Dtos.Body;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Application.Wrappers;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Interfaces.Repositories;

namespace SocialNetwork.Application.Services
{
    /// <summary>
    /// Servicio que posee los casos de uso de Usuarios
    /// </summary>
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Response<string> AddUser(UserDto userDto)
        {
            var userList = _userRepository.GetAll();
            var userExists = userList.Where(x => x.UserName == userDto.UserName).FirstOrDefault();
            if (userExists != null)
            {
                return new Response<string>($"{userDto.UserName} ya existe en el sistema");
            }
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = userDto.UserName,
            };
            _userRepository.Add(user);
            return new Response<string>($"{userDto.UserName} fue creado exitosamente");
        }
    }
}
