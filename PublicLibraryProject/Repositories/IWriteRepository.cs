using PublicLibraryApp.Entities;

namespace PublicLibraryApp.Repositories
{
    public interface IWriteRepository<T> where T : class, IEntity
    {
        void Add(T item);
        void Remove(T item);
        void Save();
    }
}