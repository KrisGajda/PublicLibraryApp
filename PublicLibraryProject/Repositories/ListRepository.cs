using PublicLibraryApp.Entities;

namespace PublicLibraryApp.Repositories
{
    public class ListRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly List<TEntity> _items = new();

        public IEnumerable<TEntity> GetAll()
        {
            return _items.ToList();
        }
        public TEntity GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }

        public void Add(TEntity item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }

        public void Remove(TEntity item)
        {
            _items.Remove(item);
        }

        public void Save()
        {
            // Save is not required with List
        }
    }
}