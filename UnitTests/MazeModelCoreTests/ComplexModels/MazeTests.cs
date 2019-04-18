using System;
using MazeModelCore.ComplexModels;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.ComplexModels;
using Moq;
using NUnit.Framework;

namespace MazeModelCoreTests.ComplexModels
{
    [TestFixture]
    public class MazeTests
    {
        Random _rand = new Random();

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
                    Assert.IsNull(testMaze[y, x]);
                }
            }
        }

        [TestCase(20, 10)]
        [TestCase(5, 15)]
        public void Indexator_SetterAndGetterTest(int height, int width)
        {
            var testMaze = new Maze(height, width);
            var moqEntity = new Mock<IRoom>[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    moqEntity[y, x] = new Mock<IRoom>();
                    testMaze[y, x] = moqEntity[y, x].Object;
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Assert.AreSame(moqEntity[y, x].Object, testMaze[y, x]);
                }
            }
        }

        [TestCase(20, 10)]
        [TestCase(5, 15)]
        public void GetIndexRandomTest(int height, int width)
        {
            var testMaze = new Maze(height, width);

            for (int i = 0; i < 10; i++)
            {
                int y = _rand.Next(height);
                int x = _rand.Next(width);

                var mock = new Mock<IRoom>();
                testMaze[y, x] = mock.Object;
                Assert.AreEqual(testMaze.GetIndex(mock.Object), (y, x));
            }
        }

        [TestCase(20, 10)]
        [TestCase(5, 15)]
        [TestCase(50, 5)]
        [TestCase(30, 100)]
        public void CoinCountRandomTest(int height, int width)
        {
            var testMaze = new Maze(height, width);
            var res = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (_rand.Next(2) == 1)
                    {
                        var mock = new Mock<IRoom>();
                        mock.Setup(a => a.Content.ElementName).Returns(Keys.CoinKey);
                        testMaze[y, x] = mock.Object;
                        res++;
                    } 
                }
            }

            Assert.AreEqual(testMaze.CoinCount, res);
        }
    }
}