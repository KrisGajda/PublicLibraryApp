namespace PublicLibraryApp.Entities
{
    public class BoardGame : EntityBase
    {
        public string? Name { get; set; }
        public int ReleaseYear { get; set; }
        private string itemCategory;
        public override string ToString()
            => $"Id: {Id}, Name: {Name}, Release year: {ReleaseYear}";
    }
}