using System.Collections.Generic;
using MazeLogicCore.Builders;
using MazeModelCore.ComplexModels;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.Base;
using NUnit.Framework;

namespace MazeLogicCoreTests.Builders
{
    [TestFixture]
    public class WallBuilderTests
    {
        [TestCase(3, 4)]
        [TestCase(10, 15)]
        public void Build_UniqueWallCountTest(int height, int width)
        {
            var maze = new Maze(height, width);
            new RoomBuilder().Build(maze);
            new WallBuilder().Build(maze);

            var uniqueWallEntity = new List<IModelBase>();
            foreach (var room in maze.GetEnumerable())
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