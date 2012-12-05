using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

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
