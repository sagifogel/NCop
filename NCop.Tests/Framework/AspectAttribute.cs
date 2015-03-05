using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NCop.Tests
{
    [TestClass]
    class Class1
    {
        public class Test
        {
            public void Foo() {
            }
        }

        [TestMethod]
        static void OnMethodBoundaryAspect_WithoutSuppliedLifetimeStrategy_CreatesSingletonStartegy() {
            
        }
    }
}
