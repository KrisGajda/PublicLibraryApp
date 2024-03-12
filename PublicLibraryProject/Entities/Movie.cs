namespace PublicLibraryApp.Entities
{
    public class Movie : EntityBase
    {
        Category categoryValue = EntityBase.Category.Movie;
        public string? Title { get; set; }
        public string? Director { get; set; }
        public int ReleaseYear { get; set; }
        public override string ToString()
            => $"Id: {Id}, Category: {categoryValue}, " +
            $"Title: {Title}, Director: {Director}, Release year: {ReleaseYear}";
    }
}