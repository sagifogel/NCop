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

namespace NCop.Tests
{   
    [TestClass]
    class Class1
    {
        [TestMethod]
        static void OnMethodBoundaryAspect_WithoutSuppliedLifetimeStrategy_CreatesSingletonStartegy() {
            var attr =  new OnMethodBoundaryAspectAttribute();
            var builder = attr.GetBuilder(typeof(Class1));
            var aspect = builder.Build();

        }
    }
}
