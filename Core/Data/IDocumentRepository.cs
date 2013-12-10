using Core.Domain;

namespace Core.Data
{
    public interface IDocumentRepository
    {
        void SaveDocument(Document document);
        Document LoadDocument(string path);
    }
}
