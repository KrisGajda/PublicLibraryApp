using Microsoft.EntityFrameworkCore;
using PublicLibraryApp.Entities;

namespace PublicLibraryApp.Data
{
    public class PublicLibraryAppDbContext : DbContext
    {
        public DbSet<Book> Books => Set<Book>();      
        public DbSet<BoardGame> BoardGames => Set<BoardGame>();
        public DbSet<Movie> Movies => Set<Movie>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageLibraryAppDb");
        }
    }
}
