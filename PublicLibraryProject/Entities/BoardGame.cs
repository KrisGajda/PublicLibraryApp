namespace PublicLibraryApp.Entities
{
    public class BoardGame : EntityBase
    {
        public string? Name 
        {
            get { return parameterToLog1; }
            set { parameterToLog1 = value; }
        }
        public string? Type
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
            => $"Id: {Id}, Name: {Name}, Release year: {ReleaseYear}";
    }
}