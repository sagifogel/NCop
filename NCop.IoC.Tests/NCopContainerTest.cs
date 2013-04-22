using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NCop.IoC.Tests
{
	[TestClass]
	public class NCopContainerTest
	{
		public interface IFoo { string Name { get; } }
		public interface IBar { }

		public class Foo : IFoo, IDisposable
		{
            public bool IsDisposed { get; set; }

			public Foo() { }

			public Foo(string name) {
				Name = name;
			}

			public string Name { get; private set; }

            public void Dispose() {
                IsDisposed = true;    
            }
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
		public void Resolve_UsingAutoFactoryOfInterface_ThrowsRegistraionException() {
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

		[TestMethod]
		public void Resolve_UsingAsSingletonExpressionRegistrationWithFactory_ReturnsTheSameObjectForDifferentResolveCalls() {
			var container = new NCopContainer(registry => {
				registry.Register<Foo>((reg) => new Foo()).AsSingleton();
			});

			var instance = container.Resolve<Foo>();
			var instatance2 = container.Resolve<Foo>();

			Assert.AreSame(instance, instatance2);
		}

		[TestMethod]
		public void Resolve_UsingAutoFactoryAndCastingWithAsExpressionAndAfterThatUsingTheAsSingletonExpressionRegistration_ReturnsTheSameObjectForDifferentResolveCalls() {
			var container = new NCopContainer(registry => {
				registry.Register<IFoo>().As<Foo>().AsSingleton();
			});

			var instance = container.Resolve<IFoo>();
			var instatance2 = container.Resolve<IFoo>();

			Assert.AreSame(instance, instatance2);
		}

		[TestMethod]
		public void Resolve_UsingAutoFactoryThatBindsToSelf_ReturnsTheInjectedValue() {
			var container = new NCopContainer(registry => {
				registry.Register<Foo>().ToSelf();
			});

			var instance = container.Resolve<Foo>();

			Assert.IsNotNull(instance);
			Assert.IsInstanceOfType(instance, typeof(Foo));
		}

		[TestMethod]
		[ExpectedException(typeof(RegistraionException))]
		public void Resolve_UsingAutoFactoryOfInterfaceThatBindsToSelf_ThrowsRegistraionException() {
			var container = new NCopContainer(registry => {
				registry.Register<IFoo>().ToSelf();
			});

			var instance = container.Resolve<IFoo>();
		}

		[TestMethod]
		[ExpectedException(typeof(ResolutionException))]
		public void TryResolve_NotRegisteredService_ThrowsRegistraionException() {
			var container = new NCopContainer(registry => { });
			var instance = container.Resolve<IFoo>();
		}

		[TestMethod]
		public void TryResolve_NotRegisteredService_DontThrowsRegistraionExceptionAndReturnsNull() {
			var container = new NCopContainer(registry => { });
			var instance = container.TryResolve<IFoo>();

			Assert.IsNull(instance);
		}

		[TestMethod]
		public void TryResolve_NotRegisteredServiceWithMultipuleArguments_DontThrowsRegistraionExceptionAndReturnsNull() {
			var container = new NCopContainer(registry => { });
			var instance = container.TryResolve<string, int, IFoo>("NCop", 9);

			Assert.IsNull(instance);
		}

		[TestMethod]
		public void Resolve_InChildContainerUsesParentContainer_ReusesParentContainerAndReturnsTheReolvedObject() {
			var container = new NCopContainer(registry => {
				registry.Register<Foo>();
			});

			var childContainer = container.CreateChildContainer(registry => { });
			var instance = childContainer.Resolve<Foo>();

			Assert.IsNotNull(instance);
		}

		[TestMethod]
		public void ResolveInChildContainerAndInParentContainer_UsingSingletonRegistrationInParentContainer_ReturnsTheSameInstance() {
			var container = new NCopContainer(registry => {
				registry.Register<Foo>().AsSingleton();
			});

			var childContainer = container.CreateChildContainer(registry => { });
			var instance = container.Resolve<Foo>();
			var instance2 = childContainer.Resolve<Foo>();

			Assert.AreSame(instance, instance2);
		}

		[TestMethod]
		public void ResolveInChildContainerAndInParentContainer_UsingAutoRegistrationInParentContainerAsSingletonReusedWithinContainer_ReturnsTheSameInstance() {
			var container = new NCopContainer(registry => {
				registry.Register<Foo>().AsSingleton().ReusedWithinHierarchy();
			});

			var childContainer = container.CreateChildContainer(registry => { });
			var instance = container.Resolve<Foo>();
			var instance2 = childContainer.Resolve<Foo>();

			Assert.AreSame(instance, instance2);
		}

		[TestMethod]
		public void ResolveInChildContainerAndInParentContainer_UsingAutoRegistrationInParentContainerAsSingletoneReusedWithinHierarchy_ReturnsNotTheSameInstance() {
			var container = new NCopContainer(registry => {
				registry.Register<Foo>().AsSingleton().ReusedWithinContainer();
			});

			var childContainer = container.CreateChildContainer(registry => { });
			var instance1 = container.Resolve<Foo>();
			var instance2 = container.Resolve<Foo>();
			var instance3 = childContainer.Resolve<Foo>();
			var instance4 = childContainer.Resolve<Foo>();

			Assert.AreSame(instance1, instance2);
			Assert.AreNotSame(instance1, instance3);
			Assert.AreSame(instance3, instance4);
		}

        [TestMethod]
        public void DisposeResolveInChildContainerAndInParentContainer_UsingAutoRegistrationInParentContainerAsSingletonReusedWithinContainer_ReturnsTheSameInstance2() {
            var container = new NCopContainer(registry => {
                registry.Register<Foo>().OwnedByContainer();
            });

            var instance = container.Resolve<Foo>();

            Assert.IsFalse(instance.IsDisposed);
            container.Dispose();
            Assert.IsTrue(instance.IsDisposed);
        }
	}
}


