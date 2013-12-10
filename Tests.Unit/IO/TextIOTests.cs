using System.Runtime.Remoting.Messaging;
using Core.IO;
using Moq;
using NUnit.Framework;

namespace Core.Tests.Unit.IO
{
    [TestFixture]
    public class TextIOTests
    {
        [Test]
        public void Writes_Text_To_File()
        {
            // setup the mocks
            var systemIOWrapperMock = new Mock<ISystemIOWrapper>();
            systemIOWrapperMock.Setup(m => m.WriteTextToFile(It.IsAny<string>(), It.IsAny<string>()));

            var TextIO = new TextIO(systemIOWrapperMock.Object);

            TextIO.WriteDocument("anything","/yo");

            systemIOWrapperMock.VerifyAll();
        }

        [Test]
        public void Reads_Text_From_File()
        {
            // setup the mocks
            var systemIOWrapperMock = new Mock<ISystemIOWrapper>();
            systemIOWrapperMock.Setup(m => m.ReadTextFromFile(It.IsAny<string>()));

            var TextIO = new TextIO(systemIOWrapperMock.Object);

            TextIO.ReadDocument("C:/test.json");

            systemIOWrapperMock.VerifyAll();
        }

        [Test]
        public void Creates_Directory_If_It_Doesnt_Exist()
        {
            // setup the mocks
            var systemIOWrapperMock = new Mock<ISystemIOWrapper>();

            var requestedValue = "/yo/1/2/test.json"; // these three directories don't exist :)

            systemIOWrapperMock.Setup(m => m.DirectoryExists(It.IsAny<string>())).Returns<bool>(x => false);
            systemIOWrapperMock.Setup(m => m.WriteTextToFile(It.IsAny<string>(), It.IsAny<string>()));
            systemIOWrapperMock.Setup(m => m.CreateDirectory(It.IsAny<string>()));

            var TextIO = new TextIO(systemIOWrapperMock.Object);

            TextIO.WriteDocument("anything", requestedValue);

            systemIOWrapperMock.Verify(m => m.CreateDirectory(It.IsAny<string>()),Times.Exactly(3));

        }
    }
}
