using System;
using System.Collections.Generic;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Infrastructure.InMemory.Dictionaries
{
    /// <summary>
    /// Diccionario para almacenar todos las publicaciones del Sistema, se utiliza el patrón de Diseño Singleton para que solo exista una instancia
    /// </summary>
    public sealed class PostDictionary
    {
        private static readonly Lazy<PostDictionary> _instance = new Lazy<PostDictionary>(() => new PostDictionary());
        public Dictionary<Guid, Post> Posts { get; } = new Dictionary<Guid, Post>();

        public static PostDictionary Instance => _instance.Value;

        private PostDictionary() { }
    }
}
