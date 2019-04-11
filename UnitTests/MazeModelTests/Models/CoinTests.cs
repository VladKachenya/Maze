using MazeModel.Helper;
using MazeModel.Models;
using NUnit.Framework;

namespace MazeModelTests.Models
{
    [TestFixture]
    public class CoinTests
    {
        [Test]
        public void ElementNameIsColumn()
        {
            var coin = new Coin();
            Assert.AreEqual(coin.ElementName, Keys.CoinKey);
        }
    }
}