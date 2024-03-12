using PublicLibraryApp.Entities;

namespace PublicLibraryApp.Repositories
{
    public interface IWriteRepository<TEntity> where TEntity : class, IEntity
    {
        void Add(TEntity item);
        void Remove(TEntity item);
        void Save();
    }
}