using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NCop.Composite.Tests
{
    [TestClass]
    public class CompositeContainerTest
    {   
        [Named("JavaScript")]
        [Mixins(typeof(JavaScriptDeveloperMixin))]
        [TransientComposite(typeof(IPersonComposite))]
        public interface IJavaScriptPerson : IPersonComposite
        {
        }

        [Named("C#")]
        [Mixins(typeof(CSharpDeveloperMixin))]
        [TransientComposite(typeof(IPersonComposite))]
        public interface ICSharpPerson : IPersonComposite
        {
        }

        [TestMethod]
        public void CompositeContainerSameTypeRegistration_HavingTwoDifferentInterfacesAnnotatedWithDiffrentNamedAttributeAndSameCompositeAttributeCastedToDerivedType_ReturnsDiffrentTypes() {
            var container = new CompositeContainer();
            container.Configure();

            var person2 = container.TryResolve<IPersonComposite>("C#");
            var person1 = container.TryResolve<IPersonComposite>("JavaScript");

            Assert.AreNotEqual(person1, person2);
        }
    }
}
