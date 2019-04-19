using MazeLogicCore.Builders;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.Base;
using MazeModelCore.Interfases.ComplexModels;
using MazeModelCore.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeLogicCoreTests.Builders
{
    #region test class

    

    internal class CorridorBuilderForTest : CorridorBuilder
    {
        public int RecursionCounter { get; set; }

        public CorridorBuilderForTest(Func<Direction, IModelBase, IModelBase, IModelBase> corridorFactoryFunc)
            : base(corridorFactoryFunc)
        {
            RecursionCounter = 0;
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

        public int GetAllSealedNeighborsCounter { get; protected set; }
        public int BrokeWallCounter { get; protected set; }
        public int GetRandomCellCounter { get; protected set; }

        protected override List<IRoom> GetAllSealedNeighbors(IRoom room, IMaze maze)
        {
            GetAllSealedNeighborsCounter++;
            if (RecursionCounter > GetAllSealedNeighborsCounter)
            {
                return new List<IRoom>() { null, null };
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
    #endregion



    [TestFixture]
    public class CorridorBuilderTests
    {
        private Mock<Func<Direction, IModelBase, IModelBase, IModelBase>> _corridorFactoryMock;
        private Mock<IMaze> _mazeMock;
        private CorridorBuilderForTest _corridorBuilderForTest;

        [SetUp]
        public void SetUp()
        {
            _corridorFactoryMock = new Mock<Func<Direction, IModelBase, IModelBase, IModelBase>>();
            _mazeMock = new Mock<IMaze>();
            _corridorBuilderForTest = new CorridorBuilderForTest(_corridorFactoryMock.Object);
        }

        [TestCase(5)]
        public void GetRandomCellTest(int inputListCount)
        {
            int i = 0;
            var listOfRoomsMock = new List<IRoom>();

            while (i < inputListCount)
            {
                i++;
                listOfRoomsMock.Add(new Mock<IRoom>().Object);
            }

            for (i = 0; i < inputListCount * 10; i++)
            {
                var res = _corridorBuilderForTest.GetRandomCellForTest(listOfRoomsMock);
                Assert.IsTrue(listOfRoomsMock.Any(el => el.Equals(res)));
            }
        }

        #region BrokeWallTest region

        private Mock<IRoom> _room1Mock;
        private Mock<IRoom> _room2Mock;


        public void BrokeWallInitialization(Direction dirComWall1, Direction dirComWall2)
        {
            var commonWall = new Mock<Wall>();
            Func<Dictionary<Direction, IModelBase>> factory = () => new Dictionary<Direction, IModelBase>()
            {
                {Direction.Down, new Wall()},
                {Direction.Up, new Wall()},
                {Direction.Left, new Wall()} ,
                {Direction.Right, new Wall()}
            };
            var enumerableOfRoom1 = factory.Invoke();
            var enumerableOfRoom2 = factory.Invoke();
            enumerableOfRoom1[dirComWall1] = commonWall.Object;
            enumerableOfRoom2[dirComWall2] = commonWall.Object;
            _room1Mock = new Mock<IRoom>();
            _room2Mock = new Mock<IRoom>();
            _room1Mock.Setup(a => a.GetEnumerable()).Returns(enumerableOfRoom1);
            _room2Mock.Setup(a => a.GetEnumerable()).Returns(enumerableOfRoom2);
        }

        [TestCase(Direction.Left, Direction.Right)]
        [TestCase(Direction.Right, Direction.Left)]
        [TestCase(Direction.Down, Direction.Up)]
        [TestCase(Direction.Up, Direction.Down)]
        public void BrokeTheWall_SetEqualNeighborsForRoomsTest(Direction dirComWall1, Direction dirComWall2)
        {
            BrokeWallInitialization(dirComWall1, dirComWall2);
            var settingEntity = new Mock<IModelBase>();
            
            _corridorFactoryMock.Setup(a => a(dirComWall2, _room1Mock.Object, _room2Mock.Object))
                .Returns(settingEntity.Object);
            _corridorBuilderForTest.BrokeWallForTest(_room1Mock.Object, _room2Mock.Object);

            _room1Mock.Verify(a => a.SetNeighbor(settingEntity.Object, dirComWall1), Times.Once);
            _room1Mock.Verify(a => a.SetNeighbor(It.IsAny<IModelBase>(), It.IsAny<Direction>()), Times.Once);

            _room2Mock.Verify(a => a.SetNeighbor(settingEntity.Object, dirComWall2), Times.Once);
            _room2Mock.Verify(a => a.SetNeighbor(It.IsAny<IModelBase>(), It.IsAny<Direction>()), Times.Once);
        }

        [TestCase(Direction.Left, Direction.Right)]
        [TestCase(Direction.Right, Direction.Left)]
        [TestCase(Direction.Down, Direction.Up)]
        [TestCase(Direction.Up, Direction.Down)]
        public void BrokeTheWall_GetRoomsEnumerableTest(Direction dirComWall1, Direction dirComWall2)
        {
            BrokeWallInitialization(dirComWall1, dirComWall2);

            _corridorBuilderForTest.BrokeWallForTest(_room1Mock.Object, _room2Mock.Object);

            _room1Mock.Verify( a => a.GetEnumerable(), Times.Once);
            _room2Mock.Verify(a => a.GetEnumerable(), Times.Once);
        }

        [Test]
        public void BrokeTheWall_ThrowArgumentException()
        {
            _room1Mock = new Mock<IRoom>();
            _room2Mock = new Mock<IRoom>();
            _room1Mock.Setup(a => a.GetEnumerable()).Returns(new Dictionary<Direction,IModelBase>());
            _room2Mock.Setup(a => a.GetEnumerable()).Returns(new Dictionary<Direction, IModelBase>());
            Assert.Throws<ArgumentException>(() =>
                _corridorBuilderForTest.BrokeWallForTest(_room1Mock.Object, _room2Mock.Object)); 
        }
        #endregion


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

            var res = _corridorBuilderForTest.GetAllSealedNeighborsForTest(mockRoom.Object, maze.Object);
            return res.Count;
        }

        [TestCase(5)]
        [TestCase(15)]
        public void BuildTest(int recourceCounter)
        {
            _corridorBuilderForTest.RecursionCounter = recourceCounter;
            _corridorBuilderForTest.Build(_mazeMock.Object);

            Assert.AreEqual(recourceCounter - 1, _corridorBuilderForTest.BrokeWallCounter);
            Assert.AreEqual(recourceCounter * 2 - 1, _corridorBuilderForTest.GetAllSealedNeighborsCounter);
            Assert.AreEqual(recourceCounter - 1, _corridorBuilderForTest.GetRandomCellCounter);
        }
    }
}