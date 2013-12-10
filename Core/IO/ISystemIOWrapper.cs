namespace Core.IO
{
    public interface ISystemIOWrapper
    {
        void WriteTextToFile(string text, string path);
        string ReadTextFromFile(string isAny);
        bool DirectoryExists(string directory);
        bool CreateDirectory(string directory);
    }
}
