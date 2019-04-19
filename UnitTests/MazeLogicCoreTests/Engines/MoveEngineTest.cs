using System.Collections.Generic;
using MazeLogicCore.Engines;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.Base;
using MazeModelCore.Interfases.ComplexModels;
using MazeModelCore.Interfases.Models;
using Moq;
using NUnit.Framework;

namespace MazeLogicCoreTests.Engines
{
    [TestFixture]
    public class MoveEngineTest
    {
        private Mock<IMaze> _mazeMock;
        private Mock<IHero> _heroMock;
        private Mock<IRoom> _roomMock;
        private Mock<IComplexModelBase> _complexModelBaseMock;
        private MoveEngine _moveEngine;


        [SetUp]
        public void SetUp()
        {
            _mazeMock = new Mock<IMaze>();
            _heroMock = new Mock<IHero>();
            _roomMock = new Mock<IRoom>();
            _complexModelBaseMock = new Mock<IComplexModelBase>();
            _roomMock.Setup(a => a.Content.ElementName).Returns(() => Keys.HeroKey);
            _mazeMock.Setup(a => a.GetEnumerable()).Returns(() => new List<IRoom>() { _roomMock.Object });
            _moveEngine = new MoveEngine(_heroMock.Object, _mazeMock.Object);
        }

        [Test]
        public void Move_MovingHeroFromCurrentCellToNextCellTets()
        {
            bool isSetHeroToNextSell = false;
            bool isSetNullingCurrentSell = false;

            _roomMock.Setup(a => a[It.IsAny<Direction>()]).Returns((() => _complexModelBaseMock.Object));
            _complexModelBaseMock.SetupSet(a => a.Content).Callback((hero) => isSetHeroToNextSell = hero.Equals(_heroMock.Object));
            _roomMock.SetupSet(a => a.Content).Callback((@null) => isSetNullingCurrentSell = @null == null);

            _moveEngine.Move(default(Direction));

            Assert.IsTrue(isSetHeroToNextSell);
            Assert.IsTrue(isSetNullingCurrentSell);
        }

        [Test]
        public void Move_MovingHeroFromCurrentCellToNextAndBackTets()
        {
            bool isSetHeroToNextSell = false;
            bool isSetNullingCurrentSell = false;

            _roomMock.Setup(a => a[It.IsAny<Direction>()]).Returns((() => _complexModelBaseMock.Object));
            _complexModelBaseMock.Setup(a => a[It.IsAny<Direction>()]).Returns((() => _roomMock.Object));

            _complexModelBaseMock.SetupSet(a => a.Content).Callback((@null) => isSetHeroToNextSell = @null == null);
            _roomMock.SetupSet(a => a.Content).Callback((@null) => isSetNullingCurrentSell = @null == null);

            _moveEngine.Move(default(Direction));
            Assert.IsFalse(isSetHeroToNextSell);
            Assert.IsTrue(isSetNullingCurrentSell);

            _moveEngine.Move(default(Direction));

            Assert.IsTrue(isSetHeroToNextSell);
            Assert.IsFalse(isSetNullingCurrentSell);
        }

        [TestCase(Direction.Right)]
        [TestCase(Direction.Up)]
        [TestCase(Direction.Left)]
        [TestCase(Direction.Down)]
        public void Move_DirectionToMoveNotInvokedTest(Direction direction)
        {
            _moveEngine.Move(default(Direction));
            _roomMock.Verify(r => r[direction], Times.Never);
            _roomMock.Verify(r => r[It.IsAny<Direction>()], Times.Once);
        }

        [TestCase(Direction.Right)]
        [TestCase(Direction.Up)]
        [TestCase(Direction.Left)]
        [TestCase(Direction.Down)]
        public void Move_DirectionToMoveWasInvokedTest(Direction direction)
        {
            _roomMock.Setup(a => a[direction]).Returns((() => _complexModelBaseMock.Object));

            _moveEngine.Move(direction);
            _roomMock.Verify(r => r[direction], Times.Once);
            _roomMock.VerifySet(r => r.Content = null, Times.Once);
            _roomMock.Verify(r => r[It.IsAny<Direction>()], Times.Once);
        }
    }
}