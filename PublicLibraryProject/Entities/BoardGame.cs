namespace PublicLibraryApp.Entities
{
    public class BoardGame : EntityBase
    {
        public const string Category = "Board game";
        public string? Name { get; set; }
        public int ReleaseYear { get; set; }
        private string itemCategory;
        public override string ToString()
            => $"Id: {Id}, Category: {Category}, Name: {Name}, Release year: {ReleaseYear}";
    }
}