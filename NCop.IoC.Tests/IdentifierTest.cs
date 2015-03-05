using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NCop.IoC.Tests
{
    [TestClass]
    public class ServiceKeyTest
    {
        [TestMethod]
        public void DifferentTypesInIdentifier_ReturnsNotSameObject() {
            var identifier1 = new ServiceKey(typeof(Action), typeof(Action), "first");
            var identifier2 = new ServiceKey(typeof(Delegate), typeof(Action), "first");
            var identifier3 = new ServiceKey(typeof(Action), typeof(Action), "second");
            var identifier4 = new ServiceKey(typeof(Delegate), typeof(Action), "second");

            Assert.IsTrue(identifier1 != identifier2 &&
                          identifier1 != identifier3 &&
                          identifier1 != identifier4 &&
                          identifier2 != identifier3 &&
                          identifier2 != identifier4 &&
                          identifier3 != identifier4);
        }

        [TestMethod]
        public void SameTypesAndNameValuesInIdentifier_ReturnsAreEqual() {
            var identifier1 = new ServiceKey(typeof(Action), typeof(Delegate), "first");
            var identifier2 = new ServiceKey(typeof(Action), typeof(Delegate), "first");


            Assert.AreEqual(identifier1, identifier2);
        }
    }
}
