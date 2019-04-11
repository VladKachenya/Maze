using System;
using MazeModel.Base;
using NUnit.Framework;

namespace MazeModelTests.Base
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
        [TestCase("123")]
        [TestCase("ewr23q4fda345345dsfasdfasd")]
        [TestCase("1")]
        [TestCase("324165748sdf")]
        public void ElementNameTest(string elementName)
        {
            var model = new ModelBaseClassForTest(elementName);
            Assert.AreEqual(model.ElementName, elementName);
        }

        [Test]
        public void NewModelBaseArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new ModelBaseClassForTest(null));

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("            ")]
        public void NewModelBaseArgumentException(string arg) =>
            Assert.Throws<ArgumentException>(() => new ModelBaseClassForTest(arg));
    }
}