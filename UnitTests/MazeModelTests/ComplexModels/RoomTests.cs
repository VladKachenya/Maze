using System;
using MazeModel.ComplexModels;
using MazeModel.Helper;
using MazeModel.Interfases.Base;
using Moq;
using NUnit.Framework;

namespace MazeModelTests.ComplexModels
{
    [TestFixture]
    public class RoomTests
    {
        private Func<string, Mock<IModelBase>> _modelBaseMockFactory;

        [SetUp]
        public void SetUpVoid()
        {
            _modelBaseMockFactory = (name) =>
            {
                var res = new Mock<IModelBase>();
                res.Setup(a => a.ElementName).Returns(name);
                return res;
            };
        }

        [Test]
        public void GetElementName_RoomKeyReterned()
        {
            var entity = new Room();
            Assert.AreEqual(Keys.RoomKey, entity.ElementName);
        }

        [TestCase(Direction.Left)]
        [TestCase(Direction.Down)]
        [TestCase(Direction.Right)]
        [TestCase(Direction.Up)]
        public void SetHeighbor_DirectionIModelBase_IndexatorDirectonIndexIModelBaseReterned(Direction direction)
        {
            var testEntity = new Room();
            var mockEntity = _modelBaseMockFactory.Invoke("str");

            testEntity.SetNeighbor(mockEntity.Object, direction);
            Assert.AreSame(mockEntity.Object, testEntity[direction]);
        }

        public bool IsSealedTest(params Tuple<Direction, IModelBase>[] models)
        {
            var testEntity = new Room();

            foreach (var model in models)
            {
                testEntity.SetNeighbor(model.Item2, model.Item1);    
            }

            return testEntity.IsSealed;
        }
    }
}