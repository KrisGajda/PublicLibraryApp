using PublicLibraryApp.Entities;

namespace PublicLibraryApp.Repositories
{
    public interface IReadRepository<out T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}