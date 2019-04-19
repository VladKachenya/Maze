using System;
using System.Collections.Generic;
using System.Linq;
using MazeModelCore.ComplexModels;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.Base;
using Moq;
using NUnit.Framework;

namespace MazeModelCoreTests.ComplexModels
{
    [TestFixture]
    public class RoomTests
    {
        private Room _room;

        private static Func<string, Mock<IModelBase>> ModelBaseMockFactory => (name) =>
        {
            var res = new Mock<IModelBase>();
            res.Setup(a => a.ElementName).Returns(name);
            return res;
        };

        [SetUp]
        public void SetUpVoid()
        {
            _room = new Room();
        }

        [Test]
        public void GetElementName_RoomKeyReterned()
        {
            Assert.AreEqual(Keys.RoomKey, _room.ElementName);
        }

        [TestCase(Direction.Left)]
        [TestCase(Direction.Down)]
        [TestCase(Direction.Right)]
        [TestCase(Direction.Up)]
        public void SetNeighbor_DirectionIModelBase_IndexatorDirectonIndexIModelBaseReterned(Direction direction)
        {
            var mockEntity = ModelBaseMockFactory.Invoke("str");
            _room.SetNeighbor(mockEntity.Object, direction);
            Assert.AreSame(mockEntity.Object, _room[direction]);
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
            foreach (var model in models)
            {
                _room.SetNeighbor(model.Item2, model.Item1);
            }

            return _room.IsSealed;
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

            foreach (var model in models)
            {
                _room.SetNeighbor(model.Item2, model.Item1);
            }

            var testEnumerable = _room.GetEnumerable();
            foreach (var model in models)
            {
                var element = testEnumerable.First(el => el.Key == model.Item1);
                Assert.AreEqual(element.Value, model.Item2);
            }
        }
        #endregion



    }
}