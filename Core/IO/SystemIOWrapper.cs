namespace Core.IO
{
    public class SystemIOWrapper : ISystemIOWrapper
    {
        public void WriteTextToFile(string text, string path)
        {
            System.IO.File.WriteAllText(path, text);
        }

        public string ReadTextFromFile(string path)
        {
            return System.IO.File.ReadAllText(path);
        }

        public bool DirectoryExists(string directory)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateDirectory(string directory)
        {
            throw new System.NotImplementedException();
        }
    }
}
