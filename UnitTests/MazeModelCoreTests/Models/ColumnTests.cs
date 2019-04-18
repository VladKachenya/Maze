using MazeModelCore.Helper;
using MazeModelCore.Models;
using NUnit.Framework;

namespace MazeModelCoreTests.Models
{
    [TestFixture]
    public class ColumnTests
    {
        [Test]
        public void ElementNameIsColumn()
        {
            var column = new Column();
            Assert.AreEqual(column.ElementName, Keys.ColumnKey);
        }
    }
}