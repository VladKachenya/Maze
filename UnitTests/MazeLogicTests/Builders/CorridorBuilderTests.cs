using System;
using System.Collections.Generic;
using System.Linq;
using MazeLogic.Builders;
using MazeModel.Helper;
using MazeModel.Interfases.Base;
using MazeModel.Interfases.ComplexModels;
using MazeModel.Models;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace MazeLogicTests.Builders
{
    internal class CorridorBuilderForTest: CorridorBuilder
    {
        private int _recursionCounter;
        public CorridorBuilderForTest(Func<Direction, IModelBase, IModelBase, IModelBase> corridorFactoryFunc, int recursionCounter = 0) 
            : base(corridorFactoryFunc)
        {
            _recursionCounter = recursionCounter;
        }

        public List<IRoom> GetAllSealedNeighborsForTest(IRoom room, IMaze maze)
        {
            return base.GetAllSealedNeighbors(room, maze);
        }

        public void BrokeWallForTest(IRoom room1, IRoom room2)
        {
            base.BrokeWall(room1, room2);
        }

        public IRoom GetRandomCellForTest(List<IRoom> rooms)
        {
            return base.GetRandomCell(rooms);
        }

        #region override for test

        public int GetAllSealedNeighborsCounter { get; protected set; } = 0;
        public int BrokeWallCounter { get; protected set; } = 0;
        public int GetRandomCellCounter { get; protected set; } = 0;

        protected override List<IRoom> GetAllSealedNeighbors(IRoom room, IMaze maze)
        {
            GetAllSealedNeighborsCounter++;
            if (_recursionCounter > GetAllSealedNeighborsCounter)
            {
                return new List<IRoom>() {null, null};
            }
            return new List<IRoom>();
        }
        protected override void BrokeWall(IRoom room1, IRoom room2)
        {
            BrokeWallCounter++;
        }

        protected override IRoom GetRandomCell(List<IRoom> rooms)
        {
            GetRandomCellCounter++;
            return null;
        }
        #endregion

    }

    [TestFixture]
    public class CorridorBuilderTests
    {
        private Mock<Func<Direction, IModelBase, IModelBase, IModelBase>> _corridorFactoryMock;
        private Mock<IMaze> _mazeMock;
        private CorridorBuilder _testEntity;

        [SetUp]
        public void SetUp()
        {
            _corridorFactoryMock = new Mock<Func<Direction, IModelBase, IModelBase, IModelBase>>();
            _mazeMock = new Mock<IMaze>();

        }

        [TestCase(5)]
        public void GetRandomCellTest(int inputListCount)
        {
            int i = 0;
            var entityForTest = new CorridorBuilderForTest(_corridorFactoryMock.Object);
            var listOfRoomsMock = new List<IRoom>();

            while (i < inputListCount)
            {
                i++;
                listOfRoomsMock.Add(new Mock<IRoom>().Object);
            }

            for (i = 0; i < inputListCount * 10; i++)
            {
                var res = entityForTest.GetRandomCellForTest(listOfRoomsMock);
                Assert.IsTrue(listOfRoomsMock.Any(el => el.Equals(res)));
            }
        }

        [TestCase(Direction.Left, Direction.Right)]
        [TestCase(Direction.Right, Direction.Left)]
        [TestCase(Direction.Down, Direction.Up)]
        [TestCase(Direction.Up, Direction.Down)]
        public void BrokeTheWallTest(Direction dirComWall1, Direction dirComWall2)
        {
            var commonWall = new Wall();
            Func<Dictionary<Direction, IModelBase>> factory = () => new Dictionary<Direction, IModelBase>()
            {
                {Direction.Down, new Wall()},
                {Direction.Up, new Wall()},
                {Direction.Left, new Wall()} ,
                {Direction.Right, new Wall()}
            };
            var enumerableOfRoom1 = factory.Invoke();
            var enumerableOfRoom2 = factory.Invoke();
            enumerableOfRoom1[dirComWall1] = commonWall;
            enumerableOfRoom2[dirComWall2] = commonWall;
            var isSetUpForRoom1 = false;
            var isSetUpForRoom2 = false;
            var room1Mock = new Mock<IRoom>();
            var room2Mock = new Mock<IRoom>();
            var settingEntity = new Mock<IModelBase>();
            room1Mock.Setup(a => a.GetEnumerable()).Returns(enumerableOfRoom1);
            room2Mock.Setup(a => a.GetEnumerable()).Returns(enumerableOfRoom2);
            room1Mock.Setup(a => a.SetNeighbor(settingEntity.Object, dirComWall1))
                .Callback(() => isSetUpForRoom1 = true);
            room2Mock.Setup(a => a.SetNeighbor(settingEntity.Object, dirComWall2))
                .Callback(() => isSetUpForRoom2 = true);
            _corridorFactoryMock.Setup(a => a(dirComWall2, room1Mock.Object, room2Mock.Object))
                .Returns(settingEntity.Object);

            new CorridorBuilderForTest(_corridorFactoryMock.Object)
                .BrokeWallForTest(room1Mock.Object, room2Mock.Object);

            Assert.IsTrue(isSetUpForRoom1);
            Assert.IsTrue(isSetUpForRoom2);
        }

        [TestCase(true, ExpectedResult = 4)]
        [TestCase(false, ExpectedResult = 0)]
        public int GetAllSealedNeighborsTest(bool isAllSeald)
        {
            var size = (10, 10);
            var roomPoint = (5, 5);
            var mockRoom = new Mock<IRoom>();
            var maze = new Mock<IMaze>();
            int callingCount = 0;

            maze.Setup(a => a.GetIndex(mockRoom.Object)).Returns(roomPoint);
            maze.Setup(a => a.Height).Returns(size.Item1);
            maze.Setup(a => a.Width).Returns(size.Item2);
            maze.Setup(a => a[It.IsAny<int>(), It.IsAny<int>()]).Callback(() => callingCount++);
            maze.Setup(a => a[It.IsAny<int>(), It.IsAny<int>()].IsSealed).Returns(isAllSeald);

            var res = new CorridorBuilderForTest(_corridorFactoryMock.Object).
                GetAllSealedNeighborsForTest(mockRoom.Object, maze.Object);
            return res.Count;
        }

        [TestCase(5)]
        [TestCase(15)]

        public void BuildTest(int recourceCounter)
        {
            var entityForTest = new CorridorBuilderForTest(_corridorFactoryMock.Object, recourceCounter);
            entityForTest.Build(_mazeMock.Object);

            Assert.AreEqual(recourceCounter - 1, entityForTest.BrokeWallCounter);
            Assert.AreEqual(recourceCounter*2 - 1, entityForTest.GetAllSealedNeighborsCounter);
            Assert.AreEqual(recourceCounter - 1, entityForTest.GetRandomCellCounter);
        }
    }
}