using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Infrastructure.InMemory.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        T? GetById(Guid id);
        IEnumerable<T> GetAll();
    }
}
