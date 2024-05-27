using System;
using System.Collections.Generic;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Infrastructure.InMemory.Dictionaries
{
    /// <summary>
    /// Diccionario para almacenar todos los Usuarios del Sistema, se utiliza el patrón de Diseño Singleton para que solo exista una instancia
    /// </summary>
    public sealed class UsersDictionary
    {
        private static readonly Lazy<UsersDictionary> _instance = new Lazy<UsersDictionary>(() => new UsersDictionary());
        public Dictionary<Guid, User> Users { get; } = new Dictionary<Guid, User>();

        public static UsersDictionary Instance => _instance.Value;

        private UsersDictionary() { }
    }
}
