using MazeModel.Helper;
using MazeModel.Models;
using NUnit.Framework;

namespace UnitTests.MazeModel.ModelsTests
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