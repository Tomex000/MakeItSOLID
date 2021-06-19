using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FileGenerator;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arange
            Mock<IInspect> inspector = new Mock<IInspect>();
            string path = "";
            inspector.Setup(x => x.GetFormat(path)).Returns(EFileFormat.jpg);
            OldFileGenerator item = new OldFileGenerator(inspector);

            //act
            bool result = item.ValidateFile(path);

            //assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void MyTestMethod()
        {
            OldFileGenerator item = new OldFileGenerator(null);

        }
    }
}
