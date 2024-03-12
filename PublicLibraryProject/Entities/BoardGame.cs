namespace PublicLibraryApp.Entities
{
    public class BoardGame : EntityBase
    {
        public BoardGame()
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
                value = Category.BoardGame.ToString();
                itemCategory = value;
            }
        }
        public string? Name { get; set; }
        public int ReleaseYear { get; set; }
        private string itemCategory;
        public override string ToString()
            => $"Id: {Id}, Category: {itemCategory}, Name: {Name}, Release year: {ReleaseYear}";
    }
}