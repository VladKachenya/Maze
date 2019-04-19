using System;
using MazeModelCore.Base;
using NUnit.Framework;

namespace MazeModelCoreTests.Base
{
    class ModelBaseClassForTest : ModelBase
    {
        public ModelBaseClassForTest(string elementName) : base(elementName)
        {
        }
    }

    [TestFixture]
    public class ModelBaseTests
    {
        [TestCase("ewr23q4fda345345dsfasdfasd")]
        [TestCase("1")]
        public void ElementNameTest(string elementName)
        {
            var model = new ModelBaseClassForTest(elementName);
            Assert.AreEqual(model.ElementName, elementName);
        }

        [Test]
        public void Ctor_NullElementName_ArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new ModelBaseClassForTest(null));

        [TestCase("")]
        [TestCase("            ")]
        public void Ctor_EmptyWithSpaseElementName_ArgumentException(string arg) =>
            Assert.Throws<ArgumentException>(() => new ModelBaseClassForTest(arg));
    }
}