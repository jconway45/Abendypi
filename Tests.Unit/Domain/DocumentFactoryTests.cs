using System.IO;
using Core.Domain;
using NUnit.Framework;

namespace Core.Tests.Unit.Domain
{
    [TestFixture]
    public class DocumentFactoryTests
    {
        [Test]
        public void Creates_Document_With_Body_And_Path()
        {
            var documentFactory = new DocumentFactory();
            documentFactory.Create("/test.json", "This is the body of the document");
        }
    }
}
