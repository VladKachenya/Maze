using MazeModelCore.Base;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.Base;
using Moq;
using NUnit.Framework;

namespace MazeModelCoreTests.Base
{
    internal class ComplexModelBaseForTest : ComplexModelBase
    {
        public ComplexModelBaseForTest(string elementName) : base(elementName)
        {
        }

        public void SetEntity(Direction direction, IModelBase modelBase)
        {
            _naighborDictionarys.Add(direction, modelBase);
        }
    }

    [TestFixture]
    public class ComplexModelBaseTests
    {
        private string _complexModelName;
        private ComplexModelBaseForTest _complexModelBaseForTest;

        [SetUp]
        public void SetUp()
        {
            _complexModelName = "ComplexModelBaseForTest";
            _complexModelBaseForTest = new ComplexModelBaseForTest(_complexModelName);
        }

        [Test]
        public void Ctor_PassingComplexModelName_ElementNameRetetnedComplexModelName()
        {
            Assert.AreSame(_complexModelName, _complexModelBaseForTest.ElementName);
        }
        [Test]
        public void Content_SetNull_GetThis()
        {
            _complexModelBaseForTest.Content = null;
            Assert.AreSame(_complexModelBaseForTest, _complexModelBaseForTest.Content);
        }

        [Test]
        public void Content_CreateComplexModelBase_GetThis()
        {
            Assert.AreSame(_complexModelBaseForTest, _complexModelBaseForTest.Content);
        }

        [Test]
        public void Content_SetIModelBase_GetIModelBase()
        {
            var mockModelBase = new Mock<IModelBase>();
            _complexModelBaseForTest.Content = mockModelBase.Object;
            Assert.AreSame(mockModelBase.Object, _complexModelBaseForTest.Content);
        }

        [Test]
        public void IsEmpty_SetNullContent_GetTrue()
        {
            _complexModelBaseForTest.Content = new Mock<IModelBase>().Object;
            Assert.AreEqual(false, _complexModelBaseForTest.IsEmpty);
            _complexModelBaseForTest.Content = null;
            Assert.AreEqual(true, _complexModelBaseForTest.IsEmpty);
        }

        [Test]
        public void IsEmpty_CreateComplexModelBase_GetTrue()
        {
            Assert.AreEqual(true, _complexModelBaseForTest.IsEmpty);
        }

        [Test]
        public void IsEmpty_SetNotNullContent_GetFalse()
        {
            var mock = new Mock<IModelBase>();
            _complexModelBaseForTest.Content = mock.Object;
            Assert.AreEqual(false, _complexModelBaseForTest.IsEmpty);
        }


        [TestCase(Direction.Down)]
        [TestCase(Direction.Left)]
        [TestCase(Direction.Right)]
        [TestCase(Direction.Up)]
        [TestCase(0)]
        public void Indexator_GetNotSetEntity_NullReterned(Direction direction)
        {
            Assert.IsNull(_complexModelBaseForTest[direction]);
        }

        [TestCase(Direction.Down)]
        [TestCase(Direction.Left)]
        [TestCase(Direction.Right)]
        [TestCase(Direction.Up)]
        [TestCase(0)]
        public void Indexator_GetPuttedEntity_EntityReterned(Direction direction)
        {
            var mock = new Mock<IModelBase>();
            _complexModelBaseForTest.SetEntity(direction, mock.Object);
            Assert.AreEqual(_complexModelBaseForTest[direction], mock.Object);
        }


    }
}