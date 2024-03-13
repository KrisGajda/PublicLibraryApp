namespace PublicLibraryApp.Entities
{
    public class Movie : EntityBase
    {
        public const string Category = "Movie";
        public string? Title { get; set; }
        public string? Director { get; set; }
        public int ReleaseYear { get; set; }
        private string itemCategory;
        public override string ToString()
            => $"Id: {Id}, Category: {Category}, " +
            $"Title: {Title}, Director: {Director}, Release year: {ReleaseYear}";
    }
}