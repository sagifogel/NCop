using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NCop.IoC.Tests
{
    [TestClass]
    public class NCopContainerTest
    {
        public interface IFoo { string Name { get; } }
        public interface IBar { }
        public class Foo : IFoo
        {
            public Foo() { }

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
        [ExpectedException(typeof(RegistraionException))]
        public void Resolve_UsingAutoFactory_ReturnsTheInjectedValue() {
            var container = new NCopContainer(registry => {
                registry.Register<IFoo>();
            });

            var instance = container.Resolve<IFoo>();
        }

        [TestMethod]
        public void ResolveOfDependetType_UsingFactoryThatCallsResolveOfDepndencyObject_ReturnsTheInjectedValue() {
            var container = new NCopContainer(registry => {
                registry.Register<Foo>();
                registry.Register<IBar>((r) => new Bar(r.Resolve<Foo>()));
            });

            Assert.IsNotNull(container.Resolve<IBar>());
        }

        [TestMethod]
        public void Resolve_UsingFactoryWithTypedArgument_ReturnsTheInjectedValueThatHoldsTheResultOfTypedArgument() {
            var container = new NCopContainer(registry => {
                registry.Register<IFoo, string>((r, name) => new Foo(name));
            });

            var instance = container.Resolve<string, IFoo>("Test");

            Assert.IsNotNull(instance);
            Assert.AreEqual(instance.Name, "Test");
        }

        [TestMethod]
        public void Resolve_UsingAutoFactoryAndCastingUsingTheAsExpresion_ReturnsTheInjectedValue() {
            var container = new NCopContainer(registry => {
                registry.Register<IFoo>().As<Foo>();
            });

            var instance = container.Resolve<IFoo>();

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void Resolve_UsingNamedExpressionOfSpecificTypeAndAutoWithoutNameOfTheSameType_ReturnsDifferentInstancesOfTheSameType() {
            var container = new NCopContainer(registry => {
                registry.Register<Foo>().Named("NCop");
                registry.Register<Foo>();
            });

            var instance = container.Resolve<Foo>();
            var namedInstance = container.Resolve<Foo>("NCop");

            Assert.AreNotSame(namedInstance, instance);
        }

        [TestMethod]
        public void Resolve_UsingAsSingletonExpressionRegistrationWithAutoFactory_ReturnsTheSameObjectForDifferentResolveCalls() {
            var container = new NCopContainer(registry => {
                registry.Register<Foo>().AsSingleton();
            });

            var instance = container.Resolve<Foo>();
            var instatance2 = container.Resolve<Foo>();

            Assert.AreSame(instance, instatance2);
        }
    }
}


