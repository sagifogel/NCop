using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Aspects;
using NCop.Aspects.Pointcuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.LifetimeStrategies;
using NCop.Aspects.Framework;
using NCop.Aspects.Engine;

namespace NCop.Tests
{
    [TestClass]
    class Class1
    {
        public class Test
        {
            [OnMethodBoundaryAspect]
            public void Foo() {
            }
        }

        [TestMethod]
        static void OnMethodBoundaryAspect_WithoutSuppliedLifetimeStrategy_CreatesSingletonStartegy() {
            
        }
    }
}
