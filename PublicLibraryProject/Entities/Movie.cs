namespace PublicLibraryApp.Entities
{
    public class Movie : EntityBase
    {
        public string? Title { get; set; }
        public string? Director { get; set; }
        public int ReleaseYear { get; set; }
        private string itemCategory;
        public override string ToString()
            => $"Id: {Id}, " +
            $"Title: {Title}, Director: {Director}, Release year: {ReleaseYear}";
    }
}