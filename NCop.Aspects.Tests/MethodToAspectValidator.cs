using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Engine;
using NCop.Aspects.Exceptions;
using NCop.Aspects.Framework;
using System.Reflection;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class MethodToAspectValidator
    {
        public class TestInterceptionAspectWithNewMethodOfOnInvokeThatHasAReturnType : ActionInterceptionAspect
        {
            public new string OnInvoke(ActionInterceptionArgs args) {
                base.OnInvoke(args);

                return string.Empty;
            }
        }

        public class TestMethodBounadryAspectAspectWithNewMethodOfOnEntryThatHasAReturnType : OnActionBoundaryAspect
        {
            public new string OnEntry(ActionExecutionArgs args) {
                base.OnEntry(args);

                return string.Empty;
            }
        }

        public class TestMethodBounadryAspectAspectWithNewMethodOfOnSuccessThatHasAReturnType : OnActionBoundaryAspect
        {
            public new string OnSuccess(ActionExecutionArgs args) {
                base.OnEntry(args);

                return string.Empty;
            }
        }

        public class TestMethodBounadryAspectAspectWithNewMethodOfOnExceptionThatHasAReturnType : OnActionBoundaryAspect
        {
            public new string OnException(ActionExecutionArgs args) {
                base.OnException(args);

                return string.Empty;
            }
        }

        public class TestMethodBounadryAspectAspectWithNewMethodOfOnExitThatHasAReturnType : OnActionBoundaryAspect
        {
            public new string OnExit(ActionExecutionArgs args) {
                base.OnException(args);

                return string.Empty;
            }
        }

        public class TestInterceptionAspectWithNewMethodOfOnInvokeThatHasMoreThenOneArgument : ActionInterceptionAspect
        {
            public new void OnInvoke(ActionInterceptionArgs args, string s) {
                base.OnInvoke(args);
            }
        }

        public class TestMethodBounadryAspectAspectWithNewMethodOfOnEntryThatHasMoreThenOneArgument : OnActionBoundaryAspect
        {
            public new void OnEntry(ActionExecutionArgs args, string s) {
                base.OnEntry(args);
            }
        }

        public class TestMethodBounadryAspectAspectWithNewMethodOfOnSuccessThatHasMoreThenOneArgument : OnActionBoundaryAspect
        {
            public new void OnSuccess(ActionExecutionArgs args, string s) {
                base.OnSuccess(args);
            }
        }

        public class TestMethodBounadryAspectAspectWithNewMethodOfOnExceptionThatHasMoreThenOneArgument : OnActionBoundaryAspect
        {
            public new void OnException(ActionExecutionArgs args, string s) {
                base.OnException(args);
            }
        }

        public class TestMethodBounadryAspectAspectWithNewMethodOfOnExitThatHasMoreThenOneArgument : OnActionBoundaryAspect
        {
            public override void OnExit(ActionExecutionArgs args) {
                base.OnExit(args);
            }

            public void OnExit(ActionExecutionArgs args, string s) {
                base.OnExit(args);
            }
        }

        public class TestFunctionInterceptionAspect : FunctionInterceptionAspect<int>
        {
            public override void OnInvoke(FunctionInterceptionArgs<int> args) {
            }
        }

        public class TestInterceptionAspect : FunctionInterceptionAspect<string, bool>
        {
            public override void OnInvoke(FunctionInterceptionArgs<string, bool> args) {
            }
        }

        public class TestAspect : OnFunctionBoundaryAspect<string, bool>
        {
            public override void OnEntry(FunctionExecutionArgs<string, bool> args) {
            }
        }

        public class TestAspect2 : OnFunctionBoundaryAspect<bool>
        {
            public override void OnEntry(FunctionExecutionArgs<bool> args) {
            }
        }

        public class TestAspect3 : OnFunctionBoundaryAspect<string, string>
        {
            public override void OnEntry(FunctionExecutionArgs<string, string> args) {
            }
        }

        public class TestAspect4 : OnFunctionBoundaryAspect<int, bool>
        {
            public override void OnEntry(FunctionExecutionArgs<int, bool> args) {
            }
        }

        public class TestAspect5 : ActionInterceptionAspect<bool>
        {
            public override void OnInvoke(ActionInterceptionArgs<bool> args) {
                base.OnInvoke(args);
            }
        }

        public class TestAspect6 : OnActionBoundaryAspect
        {
            public override void OnEntry(ActionExecutionArgs args) {
                base.OnEntry(args);
            }
        }

        public class NoAdviceAspect : OnFunctionBoundaryAspect<string, string>
        {
        }

        public class Subject
        {
            public void MethodWithIntParamAndNoReturnType(int i) {
            }

            public bool MethodWithStringParamAndBoolReturnType(string value) {
                return true;
            }

            public void MethodWithStringParamAndVoidReturnType(string value) {
            }

            public bool MethodWithoutParamsWithBoolReturnType() {
                return true;
            }

            public void MethodWithoutParams() {
            }
        }

        [TestMethod]
        public void MethodWithStringParamAndBoolReturnType_DecoratedWithMatcheOnFunctionBoundaryAspect_ReturnsNoErrorFromValidation() {
            var method = GetMethod("MethodWithStringParamAndBoolReturnType");
            var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestAspect));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        public void ParameterlessWithReturnTypeMethod_DecoratedWithMatchedFunctionAspectsWithoutParametersAndReturnType_ReturnsNoErrorFromValidation() {
            var method = GetMethod("MethodWithoutParamsWithBoolReturnType");
            var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestAspect2));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectAnnotationException))]
        public void OnMethodBoundaryAspectAttribute_GivenAnInterceptionAspectTypeAsAnArgument_ThrowsAspectAnnotationException() {
            var method = GetMethod("MethodWithStringParamAndBoolReturnType");
            var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestInterceptionAspect));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectAnnotationException))]
        public void MethodInterceptionAspectAttribute_GivenAnOnMethodBoundaryAspectTypeAsAnArgument_ThrowsAspectAnnotationException() {
            var method = GetMethod("MethodWithStringParamAndBoolReturnType");
            var aspect = new MethodInterceptionAspectAttribute(typeof(TestAspect));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectAnnotationException))]
        public void MethodWithoutReturnType_DecoratedWithOnFunctionBoundaryAspectAttribute_ThrowsAspectAnnotationException() {
            var method = GetMethod("MethodWithStringParamAndVoidReturnType");
            var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestAspect));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void MethodWithAReturnType_DecoratedWithFunctionAspectThatHasDifferentReturnType_ThrowsAspectTypeMismatchException() {
            var method = GetMethod("MethodWithStringParamAndBoolReturnType");
            var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestAspect3));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectAnnotationException))]
        public void MethodWithAReturnType_DecoratedWithActionAspect_ThrowsAspectTypeMismatchException() {
            var method = GetMethod("MethodWithStringParamAndBoolReturnType");
            var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestAspect6));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void MethodWithOneParemeterAndReturnType_DecoratedWithFunctionAspectThatHasDifferentSetOfParameters_ThrowsAspectTypeMismatchException() {
            var method = GetMethod("MethodWithStringParamAndBoolReturnType");
            var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestAspect4));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectAnnotationException))]
        public void ParameterslessMethodAndNoReturnType_DecoratedWithFunctionAspect_ThrowsAspectAnnotationException() {
            var method = GetMethod("MethodWithoutParams");
            var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestAspect));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void ParameterslessMethodWithReturnType_DecoratedWithFunctionAspectThatHasAtLeastOneParameter_ThrowsAspectTypeMismatchException() {
            var method = GetMethod("MethodWithoutParamsWithBoolReturnType");
            var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestAspect));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AdviceNotFoundException))]
        public void Method_DecoratedWithFunctionAspectThatHasNoAdvices_ThrowsAdviceNotFoundException() {
            var method = GetMethod("MethodWithStringParamAndBoolReturnType");
            var aspect = new OnMethodBoundaryAspectAttribute(typeof(NoAdviceAspect));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        private static MethodInfo GetMethod(string name) {
            return typeof(Subject).GetMethod(name);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectAnnotationException))]
        public void MethodWithOneArgumentAndWithoutReturnType_DecoratedWithFunctionAspectThatHasOneArgumentWhichIsTheSameTypeOfTheMethodsArgument_ThrowsAspectTypeMismatchException() {
            var method = GetMethod("MethodWithIntParamAndNoReturnType");
            var aspect = new MethodInterceptionAspectAttribute(typeof(TestFunctionInterceptionAspect));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void MethodWithoutReturnType_DecoratedWithActionInterceptionAspectWithNewMethodOfOnInvokeThatHasAReturnType_ThrowsAspectTypeMismatchException() {
            var method = GetMethod("MethodWithoutParams");
            var aspect = new MethodInterceptionAspectAttribute(typeof(TestInterceptionAspectWithNewMethodOfOnInvokeThatHasAReturnType));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void MethodWithoutReturn_DecoratedWithOnActionBoundaryAspectWithNewMethodOfOnEntryThatHasAReturnType_ThrowsAspectTypeMismatchException() {
            var method = GetMethod("MethodWithoutParams");
            var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestMethodBounadryAspectAspectWithNewMethodOfOnEntryThatHasAReturnType));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void MethodWithoutReturn_DecoratedWithOnActionBoundaryAspectWithNewMethodOfOnSuccessThatHasAReturnType_ThrowsAspectTypeMismatchException() {
            var method = GetMethod("MethodWithoutParams");
            var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestMethodBounadryAspectAspectWithNewMethodOfOnSuccessThatHasAReturnType));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void MethodWithoutReturn_DecoratedWithOnActionBoundaryAspectWithNewMethodOfOnExceptionThatHasAReturnType_ThrowsAspectTypeMismatchException() {
            var method = GetMethod("MethodWithoutParams");
            var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestMethodBounadryAspectAspectWithNewMethodOfOnExceptionThatHasAReturnType));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void MethodWithoutReturn_DecoratedWithOnActionBoundaryAspectWithNewMethodOfOnExitThatHasAReturnType_ThrowsAspectTypeMismatchException() {
            var method = GetMethod("MethodWithoutParams");
            var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestMethodBounadryAspectAspectWithNewMethodOfOnExitThatHasAReturnType));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void MethodWithoutReturnType_DecoratedWithActionInterceptionAspectWithNewMethodOfOnInvokeThatHasMoreThenOneArgument_ThrowsAspectTypeMismatchException() {
            var method = GetMethod("MethodWithoutParams");
            var aspect = new MethodInterceptionAspectAttribute(typeof(TestInterceptionAspectWithNewMethodOfOnInvokeThatHasMoreThenOneArgument));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void MethodWithoutReturn_DecoratedWithOnActionBoundaryAspectWithNewMethodOfOnEntryThatHasMoreThenOneArgument_ThrowsAspectTypeMismatchException() {
            var method = GetMethod("MethodWithoutParams");
            var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestMethodBounadryAspectAspectWithNewMethodOfOnEntryThatHasMoreThenOneArgument));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void MethodWithoutReturn_DecoratedWithOnActionBoundaryAspectWithNewMethodOfOnSuccessThatHasMoreThenOneArgument_ThrowsAspectTypeMismatchException() {
            var method = GetMethod("MethodWithoutParams");
            var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestMethodBounadryAspectAspectWithNewMethodOfOnSuccessThatHasMoreThenOneArgument));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void MethodWithoutReturn_DecoratedWithOnActionBoundaryAspectWithNewMethodOfOnExceptionThatHasMoreThenOneArgument_ThrowsAspectTypeMismatchException() {
            var method = GetMethod("MethodWithoutParams");
            var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestMethodBounadryAspectAspectWithNewMethodOfOnExceptionThatHasAReturnType));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void MethodWithoutReturn_DecoratedWithOnActionBoundaryAspectWithNewMethodOfOnExitThatHasMoreThenOneArgument_ThrowsAspectTypeMismatchException() {
            var method = GetMethod("MethodWithoutParams");
            var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestMethodBounadryAspectAspectWithNewMethodOfOnExitThatHasMoreThenOneArgument));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectAnnotationException))]
        public void ParameterslessMethodWithReturnType_DecoratedWithOnActionInterceptionAspectWithOneArgumentThatHasTheSameUnderlyingTypeAsTheReturnTypeOfTheMethod_ThrowsAspectAnnotationException() {
            var method = GetMethod("MethodWithoutParamsWithBoolReturnType");
            var aspect = new MethodInterceptionAspectAttribute(typeof(TestAspect5));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectAnnotationException))]
        public void MethodWithOneParameterAndNoReturnType_DecoratedWithOnFunctionInterceptionAspectWithOneAReturnTypeThatIsTheSameUnderlyingTypeAsTheParameterOfTheMethod_ThrowsAspectAnnotationException() {
            var method = GetMethod("MethodWithIntParamAndNoReturnType");
            var aspect = new MethodInterceptionAspectAttribute(typeof(TestFunctionInterceptionAspect));

            AspectTypeValidator.ValidateMethodAspect(aspect, method);
        }
    }
}
