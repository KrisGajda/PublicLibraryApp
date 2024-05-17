using PublicLibraryApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;
using System.Text;

namespace PublicLibraryApp.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        
        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemDeleted;
       
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Add(T item)
        {
            _dbSet.Add(item);
            AddItemToRepositoryFile(item);
            ItemAdded?.Invoke(sender:this, item);
        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
            ItemDeleted?.Invoke(sender: this, item);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void AddItemToRepositoryFile(T item)
        {
            var itemToFile = item;
            var entityName = itemToFile.GetType().Name;
            if (itemToFile != null)
            {
                using (StreamWriter writerToActualRepository = new ($"{entityName} _Repository.json", true, Encoding.UTF8))
                {
                    writerToActualRepository.WriteLine(CreateJsonInput(itemToFile));
                }
                using (var writerToAudit = File.AppendText("LibraryAudit.txt"))
                {
                    
                    writerToAudit.WriteLine(LogItemAdded(itemToFile)); //nieprawidłowo zapisuje, do zrobienia
                }
            } 
        } //implementować otwieranie pliku po uruchomieniu programu
        public string LogItemAdded(T item)
        {
            var timeNow = DateTime.Now;
            var itemToFile = item;
            var entityName = itemToFile.GetType().Name;
            string log = $"[{timeNow}]-{entityName}Added-{item.SetParemetersToLog}";
            return log;
        }

        public string LogItemDeleted(T item)
        {
            var timeNow = DateTime.Now;
            var entityName = item.ToString;
            string log = $"[{timeNow}]-{entityName}Deleted-{item.SetParemetersToLog}";
            return log;
        }
        public static string? CreateJsonInput<T>(T itemToInput) where T : IEntity
        {
            
            byte[] utf8Bytes = JsonSerializer.SerializeToUtf8Bytes(itemToInput);
            string json = Encoding.UTF8.GetString(utf8Bytes);
            //var json = JsonSerializer.Serialize(itemToInput);
            return json;
        }
    }
}
