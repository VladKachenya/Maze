using MazeLogic.Builders;
using MazeModel.Interfases.ComplexModels;
using MazeModel.Interfases.Models;
using Moq;
using NUnit.Framework;
using System;
using MazeModel.Interfases.Base;

namespace MazeLogicTests.Builders
{
    [TestFixture]
    public class HeroBuilderTests
    {
        private Mock<IHero> _heroMock;
        private Mock<IMaze> _mazeMock;
        private Mock<IRoom> _roomMock;

        [SetUp]
        public void SetUp()
        {
            _mazeMock = new Mock<IMaze>();
            _heroMock = new Mock<IHero>();
            _roomMock = new Mock<IRoom>();
            _mazeMock.Setup(a => a[0, 0]).Returns(() => _roomMock.Object);
        }

        [Test]
        public void Build_SetHeroToMazeTest()
        {
            int getHeroCounter = 0;
            bool isSerHeroToMazeCounter = false;
            _roomMock.SetupSet(a => a.Content).
                Callback((obj) => isSerHeroToMazeCounter = obj.Equals(_heroMock.Object));

            new HeroBuilder(_heroMock.Object).Build(_mazeMock.Object);

            Assert.IsTrue(isSerHeroToMazeCounter);
        }

    }
}