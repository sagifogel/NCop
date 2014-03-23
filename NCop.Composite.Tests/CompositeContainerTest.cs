using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Composite.Runtime;

namespace NCop.Composite.Tests
{
    [TestClass]
    public class CompositeContainerTest
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

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext) {
            container = new CompositeContainer();
            container.Configure();
        }

        [ClassCleanup()]
        public static void MyClassCleanup() {
            container.Dispose();
        }

        #endregion

        [Named("JavaScript")]
        [Mixins(typeof(JavaScriptDeveloperMixin))]
        [TransientComposite(As = typeof(IPersonComposite))]
        public interface IJavaScriptPerson : IPersonComposite
        {
        }

        [Named("C#")]
        [Mixins(typeof(CSharpDeveloperMixin))]
        [TransientComposite(As = typeof(IPersonComposite))]
        public interface ICSharpPerson : IPersonComposite
        {
        }

        [TransientComposite]
        [Mixins(typeof(GenericCovariantDeveloper<CSharpLanguage>))]
        public interface ICovariantCSharpDeveloper : ICovariantDeveloper<MSILLanguage>
        {
        }

        [TransientComposite]
        [Mixins(typeof(GenericDeveloper<CSharpLanguage>))]
        public interface IGenericDeveloperWithCSharpArgument : IDeveloper<CSharpLanguage>
        {
        }

        [TransientComposite]
        [Mixins(typeof(GenericCSharpDeveloperImpl))]
        public interface IGenericCSharpDeveloper : IDeveloper<CSharpLanguage>
        {
        }

        [TestMethod]
        public void CompositeContainerSameTypeRegistration_HavingTwoDifferentInterfacesAnnotatedWithDiffrentNamedAttributeAndSameCompositeAttributeCastedToDerivedType_ReturnsDiffrentTypes() {
            var person2 = container.TryResolveNamed<IPersonComposite>("C#");
            var person1 = container.TryResolveNamed<IPersonComposite>("JavaScript");

            Assert.AreNotEqual(person1, person2);
        }

        [TestMethod]
        public void CompositeContainerGenericTypeRegistration_OfATypeThatHasAGenericArgumentThatIsMoreDerviedFromTheContrartItImplementsAndTheContractIsCovariant_WeavesTheObjectProperly() {
            var person = container.TryResolve<ICovariantCSharpDeveloper>();

            Assert.IsNotNull(person);
            Assert.AreEqual(person.Code(), "C#");
        }

        [TestMethod]
        public void CompositeContainerTypeRegistration_OfANonGenericTypeThatImplementsAGenericContractThatHaveASpeificGenericArgument_WeavesTheObjectProperly() {
            var person = container.TryResolve<IGenericCSharpDeveloper>();

            Assert.IsNotNull(person);
            Assert.AreEqual(person.Code(), "C#");
        }
    }
}
