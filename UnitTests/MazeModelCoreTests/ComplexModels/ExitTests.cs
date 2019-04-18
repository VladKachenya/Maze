using MazeModelCore.ComplexModels;
using MazeModelCore.Helper;
using NUnit.Framework;

namespace MazeModelCoreTests.ComplexModels
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