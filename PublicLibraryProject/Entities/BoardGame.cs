namespace PublicLibraryApp.Entities
{
    public class BoardGame : EntityBase
    {
        Category categoryValue = EntityBase.Category.BoardGame;
        public string? Name { get; set; }
        public int ReleaseYear { get; set; }
        public override string ToString()
            => $"Id: {Id}, Category: {categoryValue}, Name: {Name}, Release year: {ReleaseYear}";
    }
}