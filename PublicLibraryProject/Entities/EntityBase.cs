namespace PublicLibraryApp.Entities

{
    public abstract class EntityBase : IEntity
    {
        public string? parameterToLog1;
        public string? parameterToLog2;
        public string? parameterToLog3;
        public const string FileRepoChanges = "AllRepositoriesChanges.txt";
        public string SetParemetersToLog(string param1, string param2, string param3)
        {
            param1 = parameterToLog1;
            param2 = parameterToLog2;
            param3 = parameterToLog3;
            string concatenatedParameters = $"{param1} {param2} {param3}";
            return concatenatedParameters;
        }
        public int Id { get; set; }

    }
}
