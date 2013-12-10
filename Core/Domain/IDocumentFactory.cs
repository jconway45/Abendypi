using Core.Domain;

public interface IDocumentFactory
{
    Document Create(string path, string body);
}