using MazeModelCore.Helper;
using MazeModelCore.Models;
using NUnit.Framework;

namespace MazeModelCoreTests.Models
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