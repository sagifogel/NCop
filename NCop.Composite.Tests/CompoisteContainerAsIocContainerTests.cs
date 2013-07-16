using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Composite.Framework;
using NCop.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Composite.Tests
{
    [TestClass]
    public class CompoisteContainerAsIocContainerTests
    {
        private TestContext testContextInstance;
        private static CompositeContainer container = null;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes

        #endregion

        [TestMethod]
        [ExpectedException(typeof(RegistraionException))]
        public void Resolve_UsingAutoFactoryOfInterface_ThrowsRegistraionException() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<IFoo>();
            });

            var instance = container.Resolve<IFoo>();
        }

        [TestMethod]
        public void ResolveOfDependetType_UsingFactoryThatCallsResolveOfDependencyObject_ReturnsTheResolvedInstance() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<Foo>();
                registry.Register<IBar>((r) => new Bar(r.Resolve<Foo>()));
            });

            Assert.IsNotNull(container.Resolve<IBar>());
        }

        [TestMethod]
        public void Resolve_UsingAutoFactoryAndCastingUsingTheAsExpresion_ReturnsTheResolvedInstance() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<IFoo>().As<Foo>();
            });

            var instance = container.Resolve<IFoo>();

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void Resolve_UsingNamedExpressionOfSpecificTypeAndAutoWithoutNameOfTheSameType_ReturnsDifferentInstancesOfTheSameType() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<Foo>().Named("NCop");
                registry.Register<Foo>();
            });

            var instance = container.Resolve<Foo>();
            var namedInstance = container.Resolve<Foo>("NCop");

            Assert.AreNotSame(namedInstance, instance);
        }

        [TestMethod]
        public void Resolve_UsingAsSingletonExpressionRegistrationWithAutoFactory_ReturnsTheSameObjectForDifferentResolveCalls() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<Foo>().AsSingleton();
            });

            var instance = container.Resolve<Foo>();
            var instatance2 = container.Resolve<Foo>();

            Assert.AreSame(instance, instatance2);
        }

        [TestMethod]
        public void Resolve_UsingAsSingletonExpressionRegistrationWithFactory_ReturnsTheSameObjectForDifferentResolveCalls() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<Foo>((reg) => new Foo()).AsSingleton();
            });

            var instance = container.Resolve<Foo>();
            var instatance2 = container.Resolve<Foo>();

            Assert.AreSame(instance, instatance2);
        }

        [TestMethod]
        public void Resolve_UsingAutoFactoryAndCastingWithAsExpressionAndAfterThatUsingTheAsSingletonExpressionRegistration_ReturnsTheSameObjectForDifferentResolveCalls() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<IFoo>().As<Foo>().AsSingleton();
            });

            var instance = container.Resolve<IFoo>();
            var instatance2 = container.Resolve<IFoo>();

            Assert.AreSame(instance, instatance2);
        }

        [TestMethod]
        public void Resolve_UsingAutoFactoryThatBindsToSelf_ReturnsTheResolvedInstance() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<Foo>().ToSelf();
            });

            var instance = container.Resolve<Foo>();

            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, typeof(Foo));
        }

        [TestMethod]
        [ExpectedException(typeof(RegistraionException))]
        public void Resolve_UsingAutoFactoryOfInterfaceThatBindsToSelf_ThrowsRegistraionException() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<IFoo>().ToSelf();
            });

            var instance = container.Resolve<IFoo>();
        }

        [TestMethod]
        [ExpectedException(typeof(ResolutionException))]
        public void TryResolve_NotRegisteredService_ThrowsRegistraionException() {
            var container = new CompositeContainer();
            container.Configure();

            var instance = container.Resolve<IFoo>();
        }

        [TestMethod]
        public void TryResolve_NotRegisteredService_DontThrowsRegistraionExceptionAndReturnsNull() {
            var container = new CompositeContainer();
            
            container.Configure(registry => {
                registry.Register<IFoo>();
            });
            
            var instance = container.TryResolve<IFoo>();

            Assert.IsNull(instance);
        }

        [TestMethod]
        public void Resolve_InChildContainerUsesParentContainer_ReusesParentContainerAndReturnsTheReolvedObject() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<Foo>();
            });

            var childContainer = container.CreateChildContainer();
            var instance = childContainer.Resolve<Foo>();

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void ResolveInChildContainerAndInParentContainer_UsingSingletonRegistrationInParentContainer_ReturnsTheSameInstance() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<Foo>().AsSingleton();
            });

            var childContainer = container.CreateChildContainer();
            var instance = container.Resolve<Foo>();
            var instance2 = childContainer.Resolve<Foo>();

            Assert.AreSame(instance, instance2);
        }

        [TestMethod]
        public void ResolveInChildContainerAndInParentContainer_UsingAutoRegistrationInParentContainerAsSingletonReusedWithinContainer_ReturnsTheSameInstance() {
            var container = new CompositeContainer();
            
            container.Configure(registry => {
                registry.Register<Foo>().AsSingleton().ReusedWithinHierarchy();
            });

            var childContainer = container.CreateChildContainer();
            var instance = container.Resolve<Foo>();
            var instance2 = childContainer.Resolve<Foo>();

            Assert.AreSame(instance, instance2);
        }

        [TestMethod]
        public void ResolveInChildContainerAndInParentContainer_UsingAutoRegistrationInParentContainerAsSingletoneReusedWithinHierarchy_ReturnsNotTheSameInstance() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<Foo>().AsSingleton().ReusedWithinContainer();
            });

            var childContainer = container.CreateChildContainer();
            var instance1 = container.Resolve<Foo>();
            var instance2 = container.Resolve<Foo>();
            var instance3 = childContainer.Resolve<Foo>();
            var instance4 = childContainer.Resolve<Foo>();

            Assert.AreSame(instance1, instance2);
            Assert.AreNotSame(instance1, instance3);
            Assert.AreSame(instance3, instance4);
        }

        [TestMethod]
        public void DisposeOfContainer_OfDisposableObjectWhichIsOwnedByContainer_ReturnsDispsoedIndication() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<Foo>().OwnedByContainer();
            });

            var instance = container.Resolve<Foo>();

            Assert.IsFalse(instance.IsDisposed);
            container.Dispose();
            Assert.IsTrue(instance.IsDisposed);
        }

        [TestMethod]
        public void DisposeOfParentContainer_OfDisposableObjectWhichIsOwnedByChildContainer_ReturnsDispsoedIndication() {
            var parentContainer = new CompositeContainer();
            container.Configure();

            var childContainer = parentContainer.CreateChildContainer();

            childContainer.Configure(registry => {
                registry.Register<Foo>();
            });

            var instance = childContainer.Resolve<Foo>();

            Assert.IsFalse(instance.IsDisposed);
            parentContainer.Dispose();
            Assert.IsFalse(instance.IsDisposed);
        }

        [TestMethod]
        public void DisposeOfContainer_OfDisposableObjectWhichIsOwnedExternally_ReturnsNotDispsoedIndication() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<Foo>().OwnedExternally();
            });

            var instance = container.Resolve<Foo>();

            Assert.IsFalse(instance.IsDisposed);
            container.Dispose();
            Assert.IsFalse(instance.IsDisposed);
        }

        [TestMethod]
        public void AutoRegister_WithPropertyDependency_ReturnsTheResolvedInstanceFilledWithTheAutoResolvedProperty() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<IFoo>().As<Foo>();
                registry.RegisterAuto<PropertyDependency>();
            });

            var instance = container.Resolve<PropertyDependency>();

            Assert.IsNotNull(instance.Foo);
        }

        [TestMethod]
        public void AutoRegister_WithConstructorDependencyThatHasOneDependentArgument_ReturnsTheResolvedInstanceFilledWithTheDependentArgument() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<IFoo>().As<Foo>();
                registry.RegisterAuto<CtorDependency>();
            });

            var instance = container.Resolve<CtorDependency>();

            Assert.IsNotNull(instance.Foo);
        }

        [TestMethod]
        [ExpectedException(typeof(RegistraionException))]
        public void AutoRegister_OfTypeThatHasMoreThanOneConstructorAndWithoutDependencyAttribute_ThrowsRegistraionException() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<IFoo>().As<Foo>();
                registry.RegisterAuto<AmbiguousConstructor>();
            });

            var instance = container.Resolve<AmbiguousConstructor>();
        }

        [TestMethod]
        public void AutoRegister_OfTypeThatHasMoreThanOneConstructorWithDependencyAttribute_ReturnsResolvedInstanceAndDontThrowsRegistraionException() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<IFoo>().As<Foo>();
                registry.RegisterAuto<AmbiguousConstructorFixedWithDependencyAttribute>();
            });

            var instance = container.Resolve<AmbiguousConstructorFixedWithDependencyAttribute>();

            Assert.IsNotNull(instance);
            Assert.IsNotNull(instance.Foo);
        }

        [TestMethod]
        public void AutoRegister_OfTypeWithDependencyAwareThatHasTwoDependentPropertiesThatOneOfThemIsAnnotatedWithDependencyAttribute_ReturnsResolvedInstanceWithOnlyOneDependentProperty() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<IFoo>().As<Foo>();
                registry.RegisterAuto<DependencyAwareClass>();
            });

            var instance = container.Resolve<DependencyAwareClass>();

            Assert.IsNotNull(instance.Injected);
            Assert.IsNull(instance.Ignored);
        }

        [TestMethod]
        public void AutoRegister_OfTypeThatHasTwoDependentPropertiesThatOneOfThemIsAnnotatedWithIgnoreDependency_ReturnsResolvedInstanceWithOnlyOneDependentProperty() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<IFoo>().As<Foo>();
                registry.RegisterAuto<IgnoreDependencyClass>();
            });

            var instance = container.Resolve<IgnoreDependencyClass>();

            Assert.IsNotNull(instance.Injected);
            Assert.IsNull(instance.Ignored);
        }

        [TestMethod]
        public void AutoRegister_OfTypeThatHasTwoPropertiesThatOneOfThemIsDependentAndTheOtherFilledByDependentConstructor_ReturnsResolvedInstanceWithBothPropertiesFilled() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<IFoo>().As<Foo>().AsSingleton();
                registry.RegisterAuto<Bar>();
            });

            var instance = container.Resolve<Bar>();

            Assert.IsNotNull(instance.ByCtor);
            Assert.IsNotNull(instance.ByProperty);
            Assert.AreSame(instance.ByCtor, instance.ByProperty);
        }

        [TestMethod]
        public void AutoRegister_OfInterfaceAndCastingWithAsExpressionToConcreteTypeThatHasOneDependentProperty_ReturnsResolvedInstanceWithFilledProperty() {
            var container = new CompositeContainer();

            container.Configure(registry => {
                registry.Register<Baz>().ToSelf();
                registry.RegisterAuto<IFoo>().As<Boo>();
            });

            var instance = container.Resolve<IFoo>() as Boo;

            Assert.IsNotNull(instance);
            Assert.IsNotNull(instance.Baz);
        }
    }
}
