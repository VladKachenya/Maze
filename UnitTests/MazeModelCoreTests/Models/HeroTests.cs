using MazeModelCore.Helper;
using MazeModelCore.Models;
using NUnit.Framework;

namespace MazeModelCoreTests.Models
{
    [TestFixture]
    public class HeroTests
    {
        private Hero _hero;

        [SetUp]
        public void SetUp()
        {
            _hero = new Hero();
        }

        [Test]
        public void Ctor_IsWinFalse()
        {
            Assert.AreEqual(false, _hero.IsWin);
        }

        [Test]
        public void ElementNameIsHero()
        {
            Assert.AreEqual(_hero.ElementName, Keys.HeroKey);
        }

        [TestCase(0)]
        [TestCase(4)]
        public void Collect_HeroIncrementsCoinCount(int count)
        {
            var res = count;
            for (int i = 0; i < count; i++)
            {
                _hero.Collect();
            }
            Assert.AreEqual(_hero.CoinCount, res);
        }
    }
}