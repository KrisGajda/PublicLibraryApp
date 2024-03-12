using PublicLibraryApp.Entities;

namespace PublicLibraryApp.Repositories
{
    public interface IRepository<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity>
        where TEntity : class, IEntity
    {
    }
}