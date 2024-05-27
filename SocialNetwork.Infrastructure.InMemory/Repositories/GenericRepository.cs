using System;
using System.Collections.Generic;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Infrastructure.InMemory.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly Dictionary<Guid, T> _entities;

        public GenericRepository(Dictionary<Guid, T> entities)
        {
            _entities = entities;
        }

        public void Add(T entity)
        {
            _entities[entity.Id] = entity;
        }

        public T? GetById(Guid id)
        {
            return _entities.ContainsKey(id) ? _entities[id] : null;
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.Values;
        }
    }
}
