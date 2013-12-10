using Core.Data;
using Core.Domain;
using Core.IO;
using Moq;
using NUnit.Framework;

namespace Core.Tests.Unit.Data
{
    [TestFixture]
    public class DocumentRepositoryTests
    {
        [Test]
        public void Writes_Document_To_Store()
        {
            var mockTextIO = new Mock<ITextIO>();
            mockTextIO.Setup(
                m => m.WriteDocument(
                    It.Is<string>(v => v == "test"),
                    It.Is<string>(v => v == "C:/TEST/testPath")
                ));

            IDocumentRepository documentRepository = new DocumentRepository
                (
                    "C:/TEST",mockTextIO.Object, 
                    new DocumentPathResolver(),
                    new DocumentFactory()
                );

            documentRepository.SaveDocument(new Document{body="test",path = "/testPath"});

            mockTextIO.VerifyAll();
        }

        [Test]
        public void Gets_Document_From_Store()
        {
            var mockTextIO = new Mock<ITextIO>();
            mockTextIO.Setup(
                m => m.ReadDocument(
                    It.Is<string>(v => v == "C:/TEST/testPath/doc.json")
                ));

            IDocumentRepository documentRepository = 
                new DocumentRepository
                    (
                        "C:/TEST", 
                        mockTextIO.Object, 
                        new DocumentPathResolver(),
                        new DocumentFactory()
                    );

            documentRepository.LoadDocument("/testPath/doc.json");

            mockTextIO.VerifyAll();
        }
    }
}
