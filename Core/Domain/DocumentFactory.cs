namespace Core.Domain
{
    public class DocumentFactory : IDocumentFactory 
    {
        public Document Create(string path, string body)
        {
            return new Document {path = path, body = body};
        }
    }
}
