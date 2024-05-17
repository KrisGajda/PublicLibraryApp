namespace PublicLibraryApp.Entities
{
    public class Movie : EntityBase
    {
        public string? Title
        {
            get { return parameterToLog1; }
            set { parameterToLog1 = value; }
        }
        public string? Director
        {
            get { return parameterToLog2; }
            set { parameterToLog2 = value; }
        }
        public string? ReleaseYear
        {
            get { return parameterToLog3; }
            set { parameterToLog3 = value; }
        }
        public override string ToString()
            => $"Id: {Id}, " +
            $"Title: {Title}, Director: {Director}, Release year: {ReleaseYear}";
    }
}