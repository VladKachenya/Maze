using MazeModel.Helper;
using MazeModel.Models;
using NUnit.Framework;

namespace MazeModelTests.Models
{
    [TestFixture]
    public class HeroTests
    {

        [Test]
        public void ElementNameIsHero()
        {
            var hero = new Hero();

            Assert.AreEqual(hero.ElementName, Keys.HeroKey);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        public void Collect_HeroIncrementsCoinCount(int count)
        {
            var hero = new Hero();
            var res = hero.CoinCount + count;
            for (int i = 0; i < count; i++)
            {
                hero.Collect();
            }

            Assert.AreEqual(hero.CoinCount, res);
        }
    }
}