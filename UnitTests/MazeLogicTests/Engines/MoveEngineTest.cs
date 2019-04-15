using System.Collections.Generic;
using System.Linq;
using MazeLogic.Engines;
using MazeModel.Helper;
using MazeModel.Interfases.Base;
using MazeModel.Interfases.ComplexModels;
using MazeModel.Interfases.Models;
using Moq;
using NUnit.Framework;

namespace MazeLogicTests.Engines
{
    [TestFixture]
    public class MoveEngineTest
    {
        [Test]
        public void Move_MovingHeroFromCurrentCellToNextCellTets()
        {
            bool isSetHeroToNextSell = false;
            bool isSetNullingCurrentSell = false;

            var mazeMock = new Mock<IMaze>();
            var heroMock = new Mock<IHero>();
            var cellMock1 = new Mock<IRoom>();
            var cellMock2 = new Mock<IComplexModelBase>();
            mazeMock.Setup(a => a.GetEnumerable()).Returns(() => new List<IRoom>() { cellMock1.Object });

            cellMock1.Setup(a => a.Content.ElementName).Returns(() => Keys.HeroKey);
            cellMock1.Setup(a => a[It.IsAny<Direction>()]).Returns((() => cellMock2.Object));
            cellMock2.SetupSet(a => a.Content).Callback((hero) => isSetHeroToNextSell = hero.Equals(heroMock.Object));
            cellMock1.SetupSet(a => a.Content).Callback((@null) => isSetNullingCurrentSell = @null == null);

            new MoveEngine(heroMock.Object, mazeMock.Object).Move(default(Direction));

            Assert.IsTrue(isSetHeroToNextSell);
            Assert.IsTrue(isSetNullingCurrentSell);
        }

        [Test]
        public void Move_MovingHeroFromCurrentCellToNextCellTwiceTets()
        {
            bool isSetHeroToNextSell = false;
            bool isSetNullingCurrentSell = false;

            var mazeMock = new Mock<IMaze>();
            var heroMock = new Mock<IHero>();
            var cellMock1 = new Mock<IRoom>();
            var cellMock2 = new Mock<IComplexModelBase>();
            mazeMock.Setup(a => a.GetEnumerable()).Returns(() => new List<IRoom>() { cellMock1.Object });

            cellMock1.Setup(a => a.Content.ElementName).Returns(() => Keys.HeroKey);
            cellMock1.Setup(a => a[It.IsAny<Direction>()]).Returns((() => cellMock2.Object));
            cellMock2.Setup(a => a[It.IsAny<Direction>()]).Returns((() => cellMock1.Object));

            cellMock2.SetupSet(a => a.Content).Callback((@null) => isSetHeroToNextSell = @null == null);
            cellMock1.SetupSet(a => a.Content).Callback((@null) => isSetNullingCurrentSell = @null == null);

            var testEn = new MoveEngine(heroMock.Object, mazeMock.Object);
            testEn.Move(default(Direction));
            Assert.IsFalse(isSetHeroToNextSell);
            Assert.IsTrue(isSetNullingCurrentSell);

            testEn.Move(default(Direction));

            Assert.IsTrue(isSetHeroToNextSell);
            Assert.IsFalse(isSetNullingCurrentSell);
        }
    }
}