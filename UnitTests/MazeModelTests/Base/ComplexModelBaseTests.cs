using MazeModel.Base;
using MazeModel.Helper;
using MazeModel.Interfases.Base;
using Moq;
using NUnit.Framework;

namespace MazeModelTests.Base
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
        private string complexModelName;

        [SetUp]
        public void SetUp()
        {
            complexModelName = "ComplexModelBaseForTest";
        }

        [Test]
        public void Ctor_PassingComplexModelName_ElementNameRetetnComplexModelName()
        {
            var complexModel = new ComplexModelBaseForTest(complexModelName);
            Assert.AreSame(complexModelName, complexModel.ElementName);
        }
        [Test]
        public void Content_SetNull_GetThis()
        {
            var complexModel = new ComplexModelBaseForTest(complexModelName) { Content = null };
            Assert.AreSame(complexModel, complexModel.Content);
        }

        [Test]
        public void Content_CreateComplexModelBase_GetThis()
        {
            var complexModel = new ComplexModelBaseForTest(complexModelName);
            Assert.AreSame(complexModel, complexModel.Content);
        }

        [Test]
        public void Content_SetIModelBase_GetIModelBase()
        {
            var mock = new Mock<IModelBase>();
            var testComplexModel = new ComplexModelBaseForTest(complexModelName) { Content = mock.Object };
            Assert.AreSame(mock.Object, testComplexModel.Content);
        }

        [Test]
        public void IsEmpty_SetNullContent_GetTrue()
        {
            var complexModel = new ComplexModelBaseForTest(complexModelName) { Content = null };
            Assert.AreEqual(true, complexModel.IsEmpty);
        }

        [Test]
        public void IsEmpty_CreateComplexModelBase_GetTrue()
        {
            var complexModel = new ComplexModelBaseForTest(complexModelName);
            Assert.AreEqual(true, complexModel.IsEmpty);
        }

        [Test]
        public void IsEmpty_SetNotNullContent_GetFalse()
        {
            var mock = new Mock<IModelBase>();
            var complexModel = new ComplexModelBaseForTest(complexModelName) { Content = mock.Object };
            Assert.AreEqual(false, complexModel.IsEmpty);
        }


        [TestCase(Direction.Down)]
        [TestCase(Direction.Left)]
        [TestCase(Direction.Right)]
        [TestCase(Direction.Up)]
        [TestCase(0)]
        public void Indexator_GetNotSetEntity_NullReterned(Direction direction)
        {
            var complexModel = new ComplexModelBaseForTest(complexModelName);
            Assert.IsNull(complexModel[direction]);
        }

        [TestCase(Direction.Down)]
        [TestCase(Direction.Left)]
        [TestCase(Direction.Right)]
        [TestCase(Direction.Up)]
        [TestCase(0)]
        public void Indexator_GetPuttedEntity_EntityReterned(Direction direction)
        {
            var complexModel = new ComplexModelBaseForTest(complexModelName);
            var mock = new Mock<IModelBase>();
            complexModel.SetEntity(direction, mock.Object);
            Assert.AreEqual(complexModel[direction], mock.Object);
        }


    }
}