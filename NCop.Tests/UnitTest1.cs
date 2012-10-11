using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Framework;
using System.Reflection;
using System.Linq.Expressions;

namespace NCop.Tests
{   
    
    public class Sample
    {
        [PropertyAround(AroundPropertyType.Get)]
        public int MyProperty { get; set; }

        public static void Stam() {
        }
    }

    [TestClass]
    public class UnitTest1
    {   
        [TestMethod]
        public void TestMethod1() {
        }
    }
}
