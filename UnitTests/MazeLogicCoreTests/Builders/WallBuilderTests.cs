using System.Collections.Generic;
using MazeLogicCore.Builders;
using MazeModelCore.ComplexModels;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.Base;
using Moq;
using NUnit.Framework;

namespace MazeLogicCoreTests.Builders
{
    [TestFixture]
    public class WallBuilderTests
    {
        [TestCase(10, 15)]
        [TestCase(20, 15)]
        [TestCase(1, 3)]

        public void Build_UniqueWallCountTest(int height, int width)
        {
            var roomBuilderMock = new Mock<RoomBuilder>();
            var wallBuilderMock = new Mock<WallBuilder>();
            var mazeMock = new Mock<Maze>(height, width);
            roomBuilderMock.Object.Build(mazeMock.Object);
            wallBuilderMock.Object.Build(mazeMock.Object);
            var uniqueWallEntity = new List<IModelBase>();
            foreach (var room in mazeMock.Object.GetEnumerable())
            {
                foreach (var side in room.GetEnumerable())
                {
                    if (!uniqueWallEntity.Contains(side.Value) && side.Value.ElementName == Keys.WallKey)
                    {
                        uniqueWallEntity.Add(side.Value);
                    }
                }
            }

            Assert.AreEqual((2 * (height + width) + (width - 1) * height + (height - 1) * width), uniqueWallEntity.Count);
        }
    }
}