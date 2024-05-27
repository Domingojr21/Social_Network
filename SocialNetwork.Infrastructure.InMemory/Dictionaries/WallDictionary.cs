
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Infrastructure.InMemory.Dictionaries
{
    /// <summary>
    /// Diccionario para almacenar todos los muros del Sistema, se utiliza el patrón de Diseño Singleton para que solo exista una instancia
    /// </summary>
    public sealed class WallDictionary
    {
        private static readonly Lazy<WallDictionary> _instance = new Lazy<WallDictionary>(() => new WallDictionary());
        public Dictionary<Guid, Wall> Walls { get; } = new Dictionary<Guid, Wall>();

        public static WallDictionary Instance => _instance.Value;

        private WallDictionary() { }
    }
}
