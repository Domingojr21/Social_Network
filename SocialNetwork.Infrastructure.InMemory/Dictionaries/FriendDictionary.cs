
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Infrastructure.InMemory.Dictionaries
{
    /// <summary>
    /// Diccionario para almacenar todos los amigos del Sistema, se utiliza el patrón de Diseño Singleton para que solo exista una instancia
    /// </summary>
    public sealed class FriendDictionary
    {
        private static readonly FriendDictionary _instance =  new FriendDictionary();
        public Dictionary<Guid, Friend> Friends { get; } = new Dictionary<Guid, Friend>();

        public static FriendDictionary Instance => _instance;

        private FriendDictionary() { }
    }
}
