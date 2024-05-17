namespace PublicLibraryApp.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
        string SetParemetersToLog(string param1, string param2, string param3);
    }
}
