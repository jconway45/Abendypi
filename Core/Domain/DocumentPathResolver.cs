namespace Core.Domain
{
    public class DocumentPathResolver : IDocumentPathResolver
    {
        public string ResolveAbsolutePath(string rootPath, string path)
        {           
            return rootPath + path;
        }
    }
}
