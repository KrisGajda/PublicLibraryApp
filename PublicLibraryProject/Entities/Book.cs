namespace PublicLibraryApp.Entities
{
    public class Book : EntityBase
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int PublicationYear { get; set; }
        public string ReleaseType { get; set; }
        public override string ToString()
            => $"Id: {Id}, Title: {Title}, Author: {Author}," +
            $" Release type: {ReleaseType}";

    }
}
