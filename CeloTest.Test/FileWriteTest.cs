using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace CeloTest.Test
{
    [TestFixture]
    public class FileWriteTest
    {
        [Test]
        public void _write_to_file()
        {
            Mock<ICustomer> customer = new Mock<ICustomer>();
            

            Mock<IFileWriter<ICustomer>> fileReaderMoq = new Mock<IFileWriter<ICustomer>>();
            fileReaderMoq.Setup(x => x.IsFileExists()).Returns(true);

            fileReaderMoq.Verify(x => x.WriteJson(It.IsAny<ICustomer>()));
        }
    }
}
