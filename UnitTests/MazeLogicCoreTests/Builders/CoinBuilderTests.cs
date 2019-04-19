using System;
using MazeLogicCore.Builders;
using MazeModelCore.Interfases.Base;
using MazeModelCore.Interfases.ComplexModels;
using Moq;
using NUnit.Framework;

namespace MazeLogicCoreTests.Builders
{
    internal class CoinBuilderForTest : CoinBuilder
    {
        public int GetRandomPoinWasInvokedCount { get; protected set; }
        public CoinBuilderForTest(int coinCont, Func<IModelBase> coinFactoryFunc) : base(coinCont, coinFactoryFunc)
        {
            GetRandomPoinWasInvokedCount = 0;
        }

        public (int, int) GetRandomPointWrap(int height, int width)
        {
            return base.GetRandomPoint(height, width);
        }

        protected override (int, int) GetRandomPoint(int height, int width)
        {
            GetRandomPoinWasInvokedCount++;
            return base.GetRandomPoint(height, width);
        }
    }

    [TestFixture]
    public class CoinBuilderTests
    {
        private Mock<Func<IModelBase>> _mockCoinFactory;
        //var testEntity = new CoinBuilderForTest(coinCount, _mockCoinFactory.Object);
        private Mock<IMaze> _mazeMock;
        private CoinBuilderForTest _coinBuilderForTest;

        private void Initialization(int height, int width, int coinCount)
        {
            _mazeMock = new Mock<IMaze>();
            _coinBuilderForTest = new CoinBuilderForTest(coinCount, _mockCoinFactory.Object);
            _mazeMock.Setup(a => a.Height).Returns(() => height);
            _mazeMock.Setup(a => a.Width).Returns(() => width);
            _mazeMock.Setup(a => a[It.IsAny<int>(), It.IsAny<int>()].IsEmpty).Returns(true);
        }

        [SetUp]
        public void SetUp()
        {
            _mockCoinFactory = new Mock<Func<IModelBase>>();
        }

        

        [TestCase(20, 10)]
        [TestCase(10, 20)]
        public void GetRandomPointSimpleTest(int height, int width)
        {
            var testEntity = new CoinBuilderForTest(10, _mockCoinFactory.Object);

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
            var testEntity = new CoinBuilderForTest(10, _mockCoinFactory.Object);
            Assert.Throws<ArgumentException>(() => testEntity.GetRandomPointWrap(height, width));
        }

        [TestCase(10, 20, 10)]
        [TestCase(10, 20, 0)]
        [TestCase(5, 5, 1000)]
        public void BuildMethod_GetRandomPointCountInvokedTest(int height, int width, int coinCount)
        {
            Initialization(height, width, coinCount);
            _coinBuilderForTest.Build(_mazeMock.Object);
            Assert.AreEqual(coinCount, _coinBuilderForTest.GetRandomPoinWasInvokedCount);
        }

        [TestCase(10, 20, 10)]
        [TestCase(10, 20, 0)]
        [TestCase(5, 5, 1000)]
        public void BuildMethod_MazeIsEmptyCountInvokedTest(int height, int width, int coinCount)
        {
            Initialization(height, width, coinCount);
            _coinBuilderForTest.Build(_mazeMock.Object);
            _mazeMock.VerifyGet(a => a[It.IsAny<int>(), It.IsAny<int>()].IsEmpty, Times.Exactly(coinCount));
        }

        [TestCase(10, 20, 10)]
        [TestCase(10, 20, 0)]
        [TestCase(5, 5, 1000)]
        public void BuildMethod_MazeContentStetterCountInvokedTest(int height, int width, int coinCount)
        {
            Initialization(height, width, coinCount);
            _coinBuilderForTest.Build(_mazeMock.Object);
            _mazeMock.VerifySet(a => a[It.IsAny<int>(), It.IsAny<int>()].Content, Times.Exactly(coinCount));
        }
    }
}