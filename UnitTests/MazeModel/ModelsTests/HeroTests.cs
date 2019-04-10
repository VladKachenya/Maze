using MazeModel.Helper;
using MazeModel.Models;
using NUnit.Framework;

namespace UnitTests.MazeModel.ModelsTests
{
    [TestFixture]
    public class HeroTests
    {

        [Test]
        public void IsHeroSingleton()
        {
            var hero1 = Hero.GetHero;
            var hero2 = Hero.GetHero;

            Assert.AreSame(hero1, hero2);
        }

        [Test]
        public void ElementNameIsHero()
        {
            var hero = Hero.GetHero;

            Assert.AreEqual(hero.ElementName, Keys.HeroKey);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        public void Collect_HeroIncrementsCoinCount(int count)
        {
            var hero = Hero.GetHero;
            var res = hero.CoinCount + count;
            for (int i = 0; i < count; i++)
            {
                hero.Collect();
            }

            Assert.AreEqual(hero.CoinCount, res);
        }
    }
}