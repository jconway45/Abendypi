using Core.Domain;
using NUnit.Framework;

namespace Core.Tests.Unit.Domain
{
    [TestFixture]
    public class DocumentPathResolverTests
    {
        [Test]
        public void Resolved_Full_System_Path_From_Document()
        {
            IDocumentPathResolver documentPathResolver = new DocumentPathResolver();

            string result = documentPathResolver.ResolveAbsolutePath("c:/example","/testlocation/test.json");

            Assert.AreEqual(result, "c:/example/testlocation/test.json");
        }
    }
}
