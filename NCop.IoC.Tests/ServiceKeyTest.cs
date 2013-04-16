using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NCop.IoC.Tests
{
    [TestClass]
    public class ServiceKeyTest
    {
        [TestMethod]
        public void DifferentTypesInServiceKey_ReturnsNotSameObject() {
            var serviceKey1 = new ServiceKey("first", typeof(Action));
            var serviceKey2 = new ServiceKey("first", typeof(Delegate));
            var serviceKey3 = new ServiceKey("second", typeof(Action));
            var serviceKey4 = new ServiceKey("second", typeof(Delegate));

            Assert.IsTrue(serviceKey1 != serviceKey2 && 
                          serviceKey1 != serviceKey3 &&
                          serviceKey1 != serviceKey4 &&
                          serviceKey2 != serviceKey3 && 
                          serviceKey2 != serviceKey4 &&
                          serviceKey3 != serviceKey4);
        }
    }
}
