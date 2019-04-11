using MazeModel.ComplexModels;
using MazeModel.Helper;
using MazeModel.Interfases.Base;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeModelTests.ComplexModels
{
    [TestFixture]
    public class RoomTests
    {
        private static Func<string, Mock<IModelBase>> ModelBaseMockFactory => (name) =>
        {
            var res = new Mock<IModelBase>();
            res.Setup(a => a.ElementName).Returns(name);
            return res;
        };

        [SetUp]
        public void SetUpVoid()
        {

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
            var mockEntity = ModelBaseMockFactory.Invoke("str");

            testEntity.SetNeighbor(mockEntity.Object, direction);
            Assert.AreSame(mockEntity.Object, testEntity[direction]);
        }

        #region IsSealedTests

        public static IEnumerable<TestCaseData> DataForIsSealedTests
        {
            get
            {
                yield return new TestCaseData(new List<Tuple<Direction, IModelBase>>()).Returns(false);
                yield return new TestCaseData(
                    new List<Tuple<Direction, IModelBase>>() {
                        new Tuple<Direction, IModelBase>(Direction.Down, ModelBaseMockFactory.Invoke("adfasdf").Object),
                        new Tuple<Direction, IModelBase>(Direction.Up, ModelBaseMockFactory.Invoke("adfasdf").Object),
                        new Tuple<Direction, IModelBase>(Direction.Left, ModelBaseMockFactory.Invoke("adfasdf").Object),
                        new Tuple<Direction, IModelBase>(Direction.Right, ModelBaseMockFactory.Invoke("adfasdf").Object)
                    }).Returns(false);
                yield return new TestCaseData(
                    new List<Tuple<Direction, IModelBase>>() {
                        new Tuple<Direction, IModelBase>(Direction.Down, ModelBaseMockFactory.Invoke(Keys.WallKey).Object),
                        new Tuple<Direction, IModelBase>(Direction.Up, ModelBaseMockFactory.Invoke(Keys.WallKey).Object),
                        new Tuple<Direction, IModelBase>(Direction.Left, ModelBaseMockFactory.Invoke(Keys.WallKey).Object),
                        new Tuple<Direction, IModelBase>(Direction.Left, ModelBaseMockFactory.Invoke(Keys.WallKey).Object)
                    }).Returns(false);
                yield return new TestCaseData(
                    new List<Tuple<Direction, IModelBase>>() {
                        new Tuple<Direction, IModelBase>(Direction.Down, ModelBaseMockFactory.Invoke(Keys.WallKey).Object),
                        new Tuple<Direction, IModelBase>(Direction.Up, ModelBaseMockFactory.Invoke(Keys.WallKey).Object),
                        new Tuple<Direction, IModelBase>(Direction.Left, ModelBaseMockFactory.Invoke(Keys.WallKey).Object),
                        new Tuple<Direction, IModelBase>(Direction.Right, ModelBaseMockFactory.Invoke(Keys.WallKey).Object)
                    }).Returns(true);
            }
        }

        [TestCaseSource(nameof(DataForIsSealedTests))]
        public bool IsSealedTest(IEnumerable<Tuple<Direction, IModelBase>> models)
        {
            var testEntity = new Room();

            foreach (var model in models)
            {
                testEntity.SetNeighbor(model.Item2, model.Item1);
            }

            return testEntity.IsSealed;
        }
        #endregion

        #region GetEnumerableTests

        public static IEnumerable<TestCaseData> GetEnumerable
        {
            get
            {
                yield return new TestCaseData(new List<Tuple<Direction, IModelBase>>());
                yield return new TestCaseData(
                    new List<Tuple<Direction, IModelBase>>() {
                        new Tuple<Direction, IModelBase>(Direction.Down, ModelBaseMockFactory.Invoke("adfasdf").Object),
                        new Tuple<Direction, IModelBase>(Direction.Up, ModelBaseMockFactory.Invoke("adfasdf").Object),
                        new Tuple<Direction, IModelBase>(Direction.Left, ModelBaseMockFactory.Invoke("adfasdf").Object),
                        new Tuple<Direction, IModelBase>(Direction.Right, ModelBaseMockFactory.Invoke("adfasdf").Object)
                    });
                yield return new TestCaseData(
                    new List<Tuple<Direction, IModelBase>>() {
                        new Tuple<Direction, IModelBase>(Direction.Down, ModelBaseMockFactory.Invoke(Keys.WallKey).Object),
                        new Tuple<Direction, IModelBase>(Direction.Up, ModelBaseMockFactory.Invoke(Keys.WallKey).Object),
                        new Tuple<Direction, IModelBase>(Direction.Left, ModelBaseMockFactory.Invoke(Keys.WallKey).Object),
                        new Tuple<Direction, IModelBase>(Direction.Right, ModelBaseMockFactory.Invoke(Keys.WallKey).Object)
                    });
            }
        }

        [TestCaseSource(nameof(GetEnumerable))]
        public void GetEnumerableTest(IEnumerable<Tuple<Direction, IModelBase>> models)
        {
            var testEntity = new Room();

            foreach (var model in models)
            {
                testEntity.SetNeighbor(model.Item2, model.Item1);
            }

            var testEnumerable = testEntity.GetEnumerable();
            foreach (var model in models)
            {
                var element = testEnumerable.First(el => el.Key == model.Item1);
                Assert.AreEqual(element.Value, model.Item2);
            }
        }
        #endregion



    }
}