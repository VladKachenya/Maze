using MazeModelCore.ComplexModels;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.Base;
using Moq;
using NUnit.Framework;

namespace MazeModelCoreTests.ComplexModels
{
    [TestFixture]
    public class CorridorTests
    {
        private Mock<IModelBase> _entity1;
        private Mock<IModelBase> _entity2;

        [SetUp]
        public void SetUp()
        {
            _entity1 = new Mock<IModelBase>();
            _entity2 = new Mock<IModelBase>();
        }
        [Test]
        public void GetElementName_CoridorKeyReterned()
        {
            var corridor = new Сorridor(default(Direction), _entity1.Object, _entity2.Object);
            Assert.AreEqual(Keys.СorridorKey, corridor.ElementName);
        }

        [Test]
        public void Ctor_DownEntity1Entity2_DownEntity1UpEntity2IsHorizontalFalseExpects()
        {
            var corridor = new Сorridor(Direction.Down, _entity1.Object, _entity2.Object);
            Assert.AreSame(corridor[Direction.Down], _entity1.Object);
            Assert.IsNull(corridor[Direction.Right]);
            Assert.AreSame(corridor[Direction.Up], _entity2.Object);
            Assert.IsNull(corridor[Direction.Left]);
        }

        [Test]
        public void Ctor_UpEntity1Entity2_UpEntity1DownEntity2IsHorizontalFalseExpects()
        {
            var corridor = new Сorridor(Direction.Up, _entity1.Object, _entity2.Object);
            Assert.AreSame(corridor[Direction.Up], _entity1.Object);
            Assert.IsNull(corridor[Direction.Right]);
            Assert.AreSame(corridor[Direction.Down], _entity2.Object);
            Assert.IsNull(corridor[Direction.Left]);
        }

        [Test]
        public void Ctor_LeftEntity1Entity2_LeftEntity1RightEntity2IsHorizontalTrueExpects()
        {
            var corridor = new Сorridor(Direction.Left, _entity1.Object, _entity2.Object);
            Assert.AreSame(corridor[Direction.Left], _entity1.Object);
            Assert.IsNull(corridor[Direction.Up]);
            Assert.AreSame(corridor[Direction.Right], _entity2.Object);
            Assert.IsNull(corridor[Direction.Down]);
        }

        [Test]
        public void Ctor_RightEntity1Entity2_RightEntity1LeftEntity2IsHorizontalTrueExpects()
        {
            var corridor = new Сorridor(Direction.Right, _entity1.Object, _entity2.Object);
            Assert.AreSame(corridor[Direction.Right], _entity1.Object);
            Assert.IsNull(corridor[Direction.Up]);
            Assert.AreSame(corridor[Direction.Left], _entity2.Object);
            Assert.IsNull(corridor[Direction.Down]);
        }

        [Test]
        public void Ctor_DownEntity1Entity2_IsHorizontalFalseExpects()
        {
            var corridor = new Сorridor(Direction.Down, _entity1.Object, _entity2.Object);
            Assert.AreEqual(corridor.IsHorizontal, false);
        }

        [Test]
        public void Ctor_UpEntity1Entity2_IsHorizontalFalseExpects()
        {
            var corridor = new Сorridor(Direction.Up, _entity1.Object, _entity2.Object);
            Assert.AreEqual(corridor.IsHorizontal, false);
        }

        [Test]
        public void Ctor_LeftEntity1Entity2_IsHorizontalTrueExpects()
        {
            var corridor = new Сorridor(Direction.Left, _entity1.Object, _entity2.Object);
            Assert.AreEqual(corridor.IsHorizontal, true);
        }

        [Test]
        public void Ctor_RightEntity1Entity2_IsHorizontalTrueExpects()
        {
            var corridor = new Сorridor(Direction.Right, _entity1.Object, _entity2.Object);
            Assert.AreEqual(corridor.IsHorizontal, true);
        }
    }
}