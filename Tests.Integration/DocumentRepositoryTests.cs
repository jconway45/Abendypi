using System.Configuration;
using Core.Data;
using NUnit.Framework;

namespace Tests.Integration
{
    [TestFixture]
    public class DocumentRepositoryTests
    {
        [Test]
        public void Writes_File_To_system()
        {
            var testDirectory = ConfigurationManager.AppSettings["testDirectory"];

            var repository = new DocumentRepository(testDirectory);

            repository.
        }
    }
}
