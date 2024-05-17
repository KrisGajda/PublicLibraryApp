using System.Net.NetworkInformation;

namespace PublicLibraryApp.Entities
{
    public class Book : EntityBase
    {
        public string? Title
        {
            get { return parameterToLog1; }
            set { parameterToLog1 = value; }
        }
        public string? Author
        {
            get { return parameterToLog2; }
            set { parameterToLog2 = value; }
        }
        public string? PublicationYear 
        {
            get { return parameterToLog3; }
            set { parameterToLog3 = value; }
        }

        public override string ToString()
            => $"Id: {Id}, Title: {Title}, Author: {Author}," +
            $" Publication year: {PublicationYear}";
    }
}