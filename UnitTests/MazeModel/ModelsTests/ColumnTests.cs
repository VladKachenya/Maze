using MazeModel.Helper;
using MazeModel.Models;
using NUnit.Framework;

namespace UnitTests.MazeModel.ModelsTests
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