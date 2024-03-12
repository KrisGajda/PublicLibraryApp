namespace PublicLibraryApp.Entities
{
    public class Movie : EntityBase
    {
        public Movie()
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
                value = Category.Movie.ToString();
                itemCategory = value;
            }
        }
        public string? Title { get; set; }
        public string? Director { get; set; }
        public int ReleaseYear { get; set; }
        private string itemCategory;
        public override string ToString()
            => $"Id: {Id}, Category: {itemCategory}, " +
            $"Title: {Title}, Director: {Director}, Release year: {ReleaseYear}";
    }
}