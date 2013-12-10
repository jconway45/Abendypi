using Core.Domain;

public interface IDocumentPathResolver
{
    string ResolveAbsolutePath(string rootPath, string path);
}