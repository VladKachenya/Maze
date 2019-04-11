using MazeModel.ComplexModels;
using NUnit.Framework;
using System;
using MazeModel.Helper;

namespace MazeModelTests.ComplexModels
{
    [TestFixture]
    public class MazeTests
    {
        [TestCase(5, 10)]
        [TestCase(15035, 13548)]
        public void Ctor_HeightAndWidthTest(int height, int width)
        {
            var testMaze = new Maze(height, width);

            Assert.AreEqual(testMaze.Height, height);
            Assert.AreEqual(testMaze.Width, width);
        }

        [TestCase(0, 10)]
        [TestCase(15035, 0)]
        [TestCase(0, 0)]
        [TestCase(-1, 13548)]
        [TestCase(-101, -85)]
        [TestCase(-1, 0)]
        public void Ctor_SetsNullOrNegativeHeightAndWidt_ArgumentException(int height, int width)
        {
            Assert.That(() => new Maze(height, width), Throws.TypeOf<ArgumentException>());
        }

        [TestCase(20, 10)]
        [TestCase(5, 15)]
        public void Ctor_SetIndexatorEntityTest(int height, int width)
        {
            var testMaze = new Maze(height, width);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Assert.IsNull(testMaze[y,x]);
                }
            }
        }
    }
}