using MazeLogic.Builders;
using MazeModel.Interfases;
using MazeModel.Interfases.Base;
using MazeModel.Interfases.ComplexModels;
using Moq;
using NUnit.Framework;
using System;

namespace MazeLogicTests.Builders
{
    internal class CoinBuilderForTest : CoinBuilder
    {
        public CoinBuilderForTest(int coinCont, Func<IModelBase> coinFactoryFunc) : base(coinCont, coinFactoryFunc)
        {
        }

        public (int, int) GetRandomPointWrap(int height, int width)
        {
            return this.GetRandomPoint(height, width);
        }
    }

    [TestFixture]
    public class CoinBuilderTests
    {
        [TestCase(20, 10)]
        [TestCase(10, 20)]
        public void GetRandomPointTest(int height, int width)
        {
            var mockCoinFactory = new Mock<Func<IModelBase>>();
            var testEntity = new CoinBuilderForTest(10, mockCoinFactory.Object);

            for (int i = 0; i < 100; i++)
            {
                var res = testEntity.GetRandomPointWrap(height, width);
                Assert.IsTrue(res.Item1 >= 0 && res.Item1 < height);
                Assert.IsTrue(res.Item2 >= 0 && res.Item2 < width);
            }

        }

        [TestCase(0, 10)]
        [TestCase(10, 0)]
        [TestCase(0, 0)]
        [TestCase(-10, 20)]
        [TestCase(10, -20)]
        [TestCase(-10, -20)]
        [TestCase(-10, 0)]
        public void GetRandomPoint_HeightOrWidthLessOrEqleNull_ThrowArgumentException(int height, int width)
        {
            var mockCoinFactory = new Mock<Func<IModelBase>>();
            var testEntity = new CoinBuilderForTest(10, mockCoinFactory.Object);
            Assert.Throws<ArgumentException>(() => testEntity.GetRandomPointWrap(height, width));
        }

        [TestCase(10, 20, 10)]
        [TestCase(10, 20, 0)]
        [TestCase(5, 5, 1000)]
        public void BuilMethodTest(int height, int width, int coinCount)
        {
            int builderCount = 0;
            int factoryCount = 0;

            var mockCoinFactory = new Mock<Func<IModelBase>>();
            mockCoinFactory.Setup(a => a()).Callback(() => factoryCount++).Returns(new Mock<IModelBase>().Object);
            var testEntity = new CoinBuilderForTest(coinCount, mockCoinFactory.Object);
            var mockMaze = new Mock<IMaze>();
            mockMaze.Setup(a => a.Height).Returns(() => height);
            mockMaze.Setup(a => a.Width).Returns(() => width);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var roomMock = new Mock<IRoom>();
                    roomMock.SetupSet(a => a.Content).Callback((arg) => builderCount++);
                    roomMock.SetupGet(a => a.IsEmpty).Returns(true);
                    mockMaze.Setup(a => a[y, x]).Returns(roomMock.Object);
                }
            }

            testEntity.Build(mockMaze.Object);

            Assert.AreEqual(coinCount, builderCount);
            Assert.AreEqual(coinCount, factoryCount);

        }
    }
}