using MazeModel.ComplexModels;
using MazeModel.Helper;
using NUnit.Framework;

namespace MazeModelTests.ComplexModels
{
    [TestFixture]
    public class ExitTests
    {
        [Test]
        public void GetElementName_ExitKeyReterned()
        {
            var corridor = new Exit();
            Assert.AreEqual(Keys.ExitKey, corridor.ElementName);
        }
    }
}