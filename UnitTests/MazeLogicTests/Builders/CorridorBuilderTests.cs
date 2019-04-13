using System;
using System.Collections.Generic;
using System.Linq;
using MazeLogic.Builders;
using MazeModel.Helper;
using MazeModel.Interfases.Base;
using MazeModel.Interfases.ComplexModels;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace MazeLogicTests.Builders
{
    internal class CorridorBuilderForTest: CorridorBuilder
    {
        public CorridorBuilderForTest(Func<Direction, IModelBase, IModelBase, IModelBase> corridorFactoryFunc) 
            : base(corridorFactoryFunc)
        {
        }

        public List<IRoom> GetAllSealedNeighborsForTest(IRoom room, IMaze maze)
        {
            return GetAllSealedNeighbors(room, maze);
        }

        public void BrokeWallForTest(IRoom room1, IRoom room2)
        {
            BrokeWall(room1, room2);
        }

        public IRoom GetRandomCellForTest(List<IRoom> rooms)
        {
            return GetRandomCell(rooms);
        }
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
    }
}