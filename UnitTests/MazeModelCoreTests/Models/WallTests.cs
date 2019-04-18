using MazeModelCore.Helper;
using MazeModelCore.Models;
using NUnit.Framework;

namespace MazeModelCoreTests.Models
{
    [TestFixture]
    public class WallTests
    {
        [Test]
        public void ElementNameIsWall()
        {
            var wall = new Wall();
            Assert.AreEqual(wall.ElementName, Keys.WallKey);
        }
    }
}