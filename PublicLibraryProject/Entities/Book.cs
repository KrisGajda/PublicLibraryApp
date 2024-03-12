namespace PublicLibraryApp.Entities
{
    public class Book : EntityBase
    {
        public Book()
        {
            ItemCategory = itemCategory;
        }
        public string ItemCategory
        {
            get
            {
                return itemCategory;
            }
            set
            {
                value = Category.Book.ToString();
                itemCategory = value;
            }
        }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int PublicationYear { get; set; }
        public string ReleaseType { get; set; }
        private string itemCategory;
        public override string ToString()
            => $"Id: {Id}, Category: {itemCategory}, Title: {Title}, Author: {Author}," +
            $" Release type: {ReleaseType}";

    }
}
