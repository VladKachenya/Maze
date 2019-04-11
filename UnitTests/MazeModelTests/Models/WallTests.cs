using MazeModel.Helper;
using MazeModel.Models;
using NUnit.Framework;

namespace MazeModelTests.Models
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