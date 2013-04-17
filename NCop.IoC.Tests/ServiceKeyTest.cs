using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NCop.IoC.Tests
{
    [TestClass]
    public class identifierTest
    {
        [TestMethod]
        public void DifferentTypesInIdentifier_ReturnsNotSameObject() {
            var identifier1 = new Identifier(typeof(Action), "first");
            var identifier2 = new Identifier(typeof(Delegate), "first");
            var identifier3 = new Identifier(typeof(Action), "second");
            var identifier4 = new Identifier(typeof(Delegate), "second");

            Assert.IsTrue(identifier1 != identifier2 &&
                          identifier1 != identifier3 &&
                          identifier1 != identifier4 &&
                          identifier2 != identifier3 &&
                          identifier2 != identifier4 &&
                          identifier3 != identifier4);
        }

        [TestMethod]
        public void SameTypesAndNameValuesInIdentifier_ReturnsAreEqual() {
            var identifier1 = new Identifier(typeof(Action), "first");
            var identifier2 = new Identifier(typeof(Action), "first");


            Assert.AreEqual(identifier1, identifier2);
        }
    }
}
