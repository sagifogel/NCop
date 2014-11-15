using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Engine;
using NCop.Aspects.Exceptions;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class PropertyToAspectValidator
    {
        public class NotAnAspect
        {
        }

        public class DummyAspect : IPropertyInterceptionAspect<string>, IPropertyInterceptionAspect
        {
            public void OnGetValue(PropertyInterceptionArgs<string> args) {
            }

            public void OnSetValue(PropertyInterceptionArgs<string> args) {
            }
        }

        public class IntPropertyInterceptionAspect : PropertyInterceptionAspect<int>
        {
            public override void OnGetValue(PropertyInterceptionArgs<int> args) {
                base.OnGetValue(args);
            }

            public override void OnSetValue(PropertyInterceptionArgs<int> args) {
                base.OnSetValue(args);
            }
        }

        public class StringPropertyInterceptionAspect : PropertyInterceptionAspect<string>
        {
            public override void OnGetValue(PropertyInterceptionArgs<string> args) {
                base.OnGetValue(args);
            }

            public override void OnSetValue(PropertyInterceptionArgs<string> args) {
                base.OnSetValue(args);
            }
        }

        public class NoAdviceAspect : PropertyInterceptionAspect<int>
        {
        }

        public class Subject
        {
            public int IntProperty { get; set; }

            public bool StringProperty { get; set; }
        }

        [TestMethod]
        public void PropertyWithPropertyInterceptionAspectAttribute_DecoratedWithMatchedPropertyAspects_ReturnsNoErrorFromValidation() {
            var property = GetProperty("IntProperty");
            var aspect = new PropertyInterceptionAspectAttribute(typeof(IntPropertyInterceptionAspect));

            AspectTypePropertyValidator.ValidatePropertyAspect(aspect, property);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void PropertyWithPropertyInterceptionAspectAttribute_DecoratedWithDifferentTypePropertyAspects_ThrowsAspectTypeMismatchException() {
            var property = GetProperty("StringProperty");
            var aspect = new PropertyInterceptionAspectAttribute(typeof(StringPropertyInterceptionAspect));

            AspectTypePropertyValidator.ValidatePropertyAspect(aspect, property);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void PropertyWithPropertyInterceptionAspectAttribute_DecoratedWithMatchedPropertyAspectsButItsAspectTypeDoesNotInheritsFromPropertyInterceptionAspect_ThrowsAspectAnnotationException() {
            var property = GetProperty("IntProperty");
            var aspect = new PropertyInterceptionAspectAttribute(typeof(DummyAspect));

            AspectTypePropertyValidator.ValidatePropertyAspect(aspect, property);
        }

        [TestMethod]
        [ExpectedException(typeof(AdviceNotFoundException))]
        public void PropertyWithPropertyInterceptionAspectAttribute_DecoratedWithPropertyAspectsThatHasNoAdvices_ThrowsAdviceNotFoundException() {
            var method = GetProperty("IntProperty");
            var aspect = new PropertyInterceptionAspectAttribute(typeof(NoAdviceAspect));

            AspectTypePropertyValidator.ValidatePropertyAspect(aspect, method);
        }

        private static PropertyInfo GetProperty(string name) {
            return typeof(Subject).GetProperty(name);
        }
    }
}
