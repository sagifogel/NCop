using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Engine;
using NCop.Aspects.Exceptions;
using NCop.Aspects.Framework;
using NCop.Core.Exceptions;
using System;
using System.Reflection;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class PropertyToAspectValidator
    {
        public class FunctionInterceptionAspect : FunctionInterceptionAspect<string>
        {
            public override void OnInvoke(FunctionInterceptionArgs<string> args) {
                base.OnInvoke(args);
            }
        }

        public class PropertyInterceptionAspect : PropertyInterceptionAspect<string>
        {
            public override void OnGetValue(PropertyInterceptionArgs<string> args) {
                base.OnGetValue(args);
            }
        }

        public class PropertyInterceptionAspectWithInt32PropertyType : PropertyInterceptionAspect<int>
        {
            public override void OnGetValue(PropertyInterceptionArgs<int> args) {
                base.OnGetValue(args);
            }
        }

        public class PropertyInterceptionAspectWithNewMethodOfOnGetValueThatHasAReturnType : PropertyInterceptionAspect<string>
        {
            public new string OnGetValue(PropertyInterceptionArgs<string> args) {
                base.OnGetValue(args);

                return string.Empty;
            }
        }

        public class PropertyInterceptionAspectWithNewMethodOfOnSetValueThatHasAReturnType : PropertyInterceptionAspect<string>
        {
            public new string OnSetValue(PropertyInterceptionArgs<string> args) {
                base.OnSetValue(args);

                return string.Empty;
            }
        }

        public class PropertyInterceptionAspectWithNewMethodOfOnGetValueThatHasMoreThenOneArgument : PropertyInterceptionAspect<string>
        {
            public new void OnGetValue(PropertyInterceptionArgs<string> args, string s) {
                base.OnSetValue(args);
            }
        }

        public class PropertyInterceptionAspectWithNewMethodOfOnSetValueThatHasMoreThenOneArgument : PropertyInterceptionAspect<string>
        {
            public new void OnSetValue(PropertyInterceptionArgs<string> args, string s) {
                base.OnSetValue(args);
            }
        }

        public class NoAdviceAspect : PropertyInterceptionAspect<string>
        {
        }

        public interface ISubject
        {
            int IntProperty { get; }
            string StringProperty { get; }
            string GetAccessorProperty { get; }
            string SetAccessorProperty { set; }
            string BothAccessorsProperty { get; set; }
        }

        public interface ISubjectExtended : ISubject
        {
            new string BothAccessorsProperty { set; }
            new string GetAccessorProperty { get; set; }
            new string SetAccessorProperty { get; set; }
        }

        public class Subject : ISubjectExtended
        {
            public int IntProperty {
                get {
                    return 0;
                }
            }

            public string StringProperty {
                get {
                    return "Subject";
                }
            }

            public string GetAccessorProperty { get; set; }
            public string SetAccessorProperty { get; set; }
            public string BothAccessorsProperty { get; set; }
        }

        private static PropertyInfo GetProperty(string name, Type type = null) {
            return (type ?? typeof(ISubject)).GetProperty(name);
        }

        [TestMethod]
        public void GetProperty_DecoratedWithMatchedPropertyInterceptionAspect_ReturnsNoErrorFromValidation() {
            var contractProperty = GetProperty("StringProperty");
            var implProperty = GetProperty("StringProperty", typeof(Subject));
            var aspect = new PropertyInterceptionAspectAttribute(typeof(PropertyInterceptionAspect));

            AspectTypeValidator.ValidatePropertyAspect(aspect, contractProperty, implProperty);
        }

        [TestMethod]
        public void PropertyWithBothAccessors_DecoratedWithMatchedPropertyInterceptionAspect_ReturnsNoErrorFromValidation() {
            var contractProperty = GetProperty("BothAccessorsProperty");
            var implProperty = GetProperty("BothAccessorsProperty", typeof(Subject));
            var aspect = new PropertyInterceptionAspectAttribute(typeof(PropertyInterceptionAspect));

            AspectTypeValidator.ValidatePropertyAspect(aspect, contractProperty, implProperty);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void GetProperty_DecoratedWithPropertyInterceptionAspectThatHasDifferentPropertyType_ThrowsAspectTypeMismatchException() {
            var contractProperty = GetProperty("StringProperty");
            var implProperty = GetProperty("StringProperty", typeof(Subject));
            var aspect = new PropertyInterceptionAspectAttribute(typeof(PropertyInterceptionAspectWithInt32PropertyType));

            AspectTypeValidator.ValidatePropertyAspect(aspect, contractProperty, implProperty);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectAnnotationException))]
        public void GetProperty_DecoratedWithAspectThatIsNotCompatibleWithPropertyInterceptionAspect_ThrowsAspectAnnotationException() {
            var contractProperty = GetProperty("StringProperty");
            var implProperty = GetProperty("StringProperty", typeof(Subject));
            var aspect = new PropertyInterceptionAspectAttribute(typeof(FunctionInterceptionAspect));

            AspectTypeValidator.ValidatePropertyAspect(aspect, contractProperty, implProperty);
        }

        [TestMethod]
        public void GetPropertyOfContractType_ImplementedByATypeThatExposesBothPropertiesAndDecoratedWithMatchedPropertyInterceptionAspect_ReturnsNoErrorFromValidation() {
            var contractProperty = GetProperty("GetAccessorProperty");
            var implProperty = GetProperty("GetAccessorProperty", typeof(Subject));
            var aspect = new PropertyInterceptionAspectAttribute(typeof(PropertyInterceptionAspect));

            AspectTypeValidator.ValidatePropertyAspect(aspect, contractProperty, implProperty);
        }

        [TestMethod]
        public void SetPropertyOfContractType_ImplementedByATypeThatExposesBothPropertiesAndDecoratedWithMatchedPropertyInterceptionAspect_ReturnsNoErrorFromValidation() {
            var contractProperty = GetProperty("SetAccessorProperty");
            var implProperty = GetProperty("SetAccessorProperty", typeof(Subject));
            var aspect = new PropertyInterceptionAspectAttribute(typeof(PropertyInterceptionAspect));

            AspectTypeValidator.ValidatePropertyAspect(aspect, contractProperty, implProperty);
        }

        [TestMethod]
        [ExpectedException(typeof(PropertyAccessorsMismatchException))]
        public void GetPropertyOfContractType_DerivedByAnInterfaceTypeThatExposesBothPropertiesAndDecoratedWithMatchedPropertyInterceptionAspect_ThrowsPropertyAccessorsMismatchException() {
            var contractProperty = GetProperty("GetAccessorProperty");
            var implProperty = GetProperty("GetAccessorProperty", typeof(ISubjectExtended));
            var aspect = new PropertyInterceptionAspectAttribute(typeof(PropertyInterceptionAspect));

            AspectTypeValidator.ValidatePropertyAspect(aspect, contractProperty, implProperty);
        }

        [TestMethod]
        [ExpectedException(typeof(PropertyAccessorsMismatchException))]
        public void SetPropertyOfContractType_DerivedByAnInterfaceTypeThatExposesBothPropertiesAndDecoratedWithMatchedPropertyInterceptionAspect_ThrowsPropertyAccessorsMismatchException() {
            var contractProperty = GetProperty("SetAccessorProperty");
            var implProperty = GetProperty("SetAccessorProperty", typeof(ISubjectExtended));
            var aspect = new PropertyInterceptionAspectAttribute(typeof(PropertyInterceptionAspect));

            AspectTypeValidator.ValidatePropertyAspect(aspect, contractProperty, implProperty);
        }

        [TestMethod]
        [ExpectedException(typeof(AdviceNotFoundException))]
        public void GetProperty_DecoratedWithMatchedPropertyInterceptionAspectThatHasNoAdvices_ThrowsAdviceNotFoundException() {
            var contractProperty = GetProperty("GetAccessorProperty");
            var implProperty = GetProperty("GetAccessorProperty", typeof(Subject));
            var aspect = new PropertyInterceptionAspectAttribute(typeof(NoAdviceAspect));

            AspectTypeValidator.ValidatePropertyAspect(aspect, contractProperty, implProperty);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void GetProperty_DecoratedWithMatchedPropertyInterceptionAspectWithNewMethodOfOnGetValueThatHasAReturnType_ThrowsAspectTypeMismatchException() {
            var contractProperty = GetProperty("GetAccessorProperty");
            var implProperty = GetProperty("GetAccessorProperty", typeof(Subject));
            var aspect = new PropertyInterceptionAspectAttribute(typeof(PropertyInterceptionAspectWithNewMethodOfOnGetValueThatHasAReturnType));

            AspectTypeValidator.ValidatePropertyAspect(aspect, contractProperty, implProperty);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void GetProperty_DecoratedWithMatchedPropertyInterceptionAspectWithNewMethodOfOnSetValueThatHasAReturnType_ThrowsAspectTypeMismatchException() {
            var contractProperty = GetProperty("GetAccessorProperty");
            var implProperty = GetProperty("GetAccessorProperty", typeof(Subject));
            var aspect = new PropertyInterceptionAspectAttribute(typeof(PropertyInterceptionAspectWithNewMethodOfOnSetValueThatHasAReturnType));

            AspectTypeValidator.ValidatePropertyAspect(aspect, contractProperty, implProperty);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void GetProperty_DecoratedWithMatchedPropertyInterceptionAspectWithNewMethodOfOnGetValueThatHasMoreThenOneArgument_ThrowsAspectTypeMismatchException() {
            var contractProperty = GetProperty("GetAccessorProperty");
            var implProperty = GetProperty("GetAccessorProperty", typeof(Subject));
            var aspect = new PropertyInterceptionAspectAttribute(typeof(PropertyInterceptionAspectWithNewMethodOfOnGetValueThatHasMoreThenOneArgument));

            AspectTypeValidator.ValidatePropertyAspect(aspect, contractProperty, implProperty);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void GetProperty_DecoratedWithMatchedPropertyInterceptionAspectWithNewMethodOfOnSetValueThatHasMoreThenOneArgument_ThrowsAspectTypeMismatchException() {
            var contractProperty = GetProperty("GetAccessorProperty");
            var implProperty = GetProperty("GetAccessorProperty", typeof(Subject));
            var aspect = new PropertyInterceptionAspectAttribute(typeof(PropertyInterceptionAspectWithNewMethodOfOnSetValueThatHasMoreThenOneArgument));

            AspectTypeValidator.ValidatePropertyAspect(aspect, contractProperty, implProperty);
        }
    }
}
