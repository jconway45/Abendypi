namespace Core.IO
{
    public class TextIO : ITextIO
    {
        private readonly ISystemIOWrapper _systemIoWrapper;

        public TextIO(ISystemIOWrapper systemIoWrapper)
        {
            _systemIoWrapper = systemIoWrapper;
        }

        public void WriteDocument(string text, string path)
        {
            _systemIoWrapper.WriteTextToFile(text, path);
        }

        public string ReadDocument(string path)
        {
            return _systemIoWrapper.ReadTextFromFile(path);
        }
    }
}
