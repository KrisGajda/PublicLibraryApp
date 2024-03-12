using PublicLibraryApp.Entities;

namespace PublicLibraryApp.Repositories
{
    public interface IReadRepository<out TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
    }
}