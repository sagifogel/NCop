using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NCop.IoC.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public interface IFoo { }
        public interface IBar { }
        public class Foo : IFoo 
        {
            public Foo() {            }
            
            public Foo(string name) {
                Name = name;
            }

            public string Name { get; private set; }
        }
        public class Bar : IBar
        {
            private IFoo _foo;

            public Bar(IFoo foo) {
                _foo = foo;
            }
        }

        [TestMethod]
        public void Resolve_UsingFactoryWithoutContainer_ReturnsTheInjectedValue() {
            var container = new NCopContainer();

            container.Register<IFoo>(() => new Foo());
            var instance = container.Resolve<IFoo>();

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void Resolve_UsingFactory_ReturnsTheInjectedValue() {
            var container = new NCopContainer();

            container.Register<IFoo>(() => new Foo());
            container.Register<IBar>((c) => new Bar(c.Resolve<IFoo>()));
            var instance = container.Resolve<IFoo>();

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void Resolve_UsingFactoryWithTypedArgument_ReturnsTheInjectedValue() {
            var container = new NCopContainer();

            container.Register<IFoo, string>((c, name) => new Foo(name));
            var instance = container.Resolve<IFoo, string>("Test");

            Assert.IsNotNull(instance);
        }
    }
}


