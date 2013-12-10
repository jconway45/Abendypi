namespace Core.IO
{
    public interface ITextIO
    {
        void WriteDocument(string text, string path);
        string ReadDocument(string path);
    }
}
