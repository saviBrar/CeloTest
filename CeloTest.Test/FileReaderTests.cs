using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace CeloTest.Test
{
    [TestFixture]
    public class FileReaderTests
    {
        [Test]
        public void _read_from_file()
        {
            Mock<ICustomer> customer = new Mock<ICustomer>();
            Mock<List<ICustomer>> customerList = new Mock<List<ICustomer>>();
            Mock<IFileReader<ICustomer>> fileReaderMoq = new Mock<IFileReader<ICustomer>>();

            fileReaderMoq.Setup(x => x.EntityList()).Returns(customerList.Object);

        }
    }
}
