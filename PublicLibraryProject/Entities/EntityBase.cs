namespace PublicLibraryApp.Entities
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }
        public enum Category
        {
            Book,
            BoardGame,
            Movie
        }
    }
}
