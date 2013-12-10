using Core.Domain;
using Core.IO;

namespace Core.Data
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly string _rootPath;
        private readonly ITextIO _textIo;
        private readonly IDocumentPathResolver _documentPathResolver;
        private readonly IDocumentFactory _documentFactory;

        public DocumentRepository(string rootPath, ITextIO textIo, IDocumentPathResolver documentPathResolver, IDocumentFactory documentFactory)
        {
            _rootPath = rootPath;
            _textIo = textIo;
            _documentPathResolver = documentPathResolver;
            _documentFactory = documentFactory;
        }

        public void SaveDocument(Document document)
        {
            _textIo.WriteDocument(
                document.body,
                _documentPathResolver.ResolveAbsolutePath(_rootPath, document.path)
               );
        }

        public Document LoadDocument(string path)
        {
            string body = 
                _textIo.ReadDocument
                    (
                        _documentPathResolver.ResolveAbsolutePath(_rootPath, path)
                    );

            return _documentFactory.Create(path,body);
        }
    }
}
