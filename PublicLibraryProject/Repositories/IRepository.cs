using PublicLibraryApp.Entities;

namespace PublicLibraryApp.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : class, IEntity
    {
    }
}