using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Engine;
using NCop.Aspects.Exceptions;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Tests
{
	[TestClass]
	public class MethodToAspectValidator
	{
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
		public class NoAdviceAspect : OnFunctionBoundaryAspect<string, string>
		{
		}

		public class Subject
		{
			public bool MethodWithStringParamAndBoolReturnType(string value) {
				return true;
			}

			public void MethodWithStringParamAndVoidReturnType(string value) {
			}

			public bool MethodWithoutParamsWithReturnType() {
				return true;
			}

			public void MethodWithoutParams() {
			}
		}

		[TestMethod]
		public void MethodWithOnMethodBoundaryAspectAttribute_DecoratedWithMatchedFunctionAspects_ReturnsNoErrorFromValidation() {
			var method = GetMethod("MethodWithStringParamAndBoolReturnType");
			var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestAspect));

			AspectTypeMethodValidator.ValidateMethodAspect(aspect, method);
		}

		[TestMethod]
		public void ParameterlessWithReturnTypeMethodWithOnMethodBoundaryAspectAttribute_DecoratedWithMatchedFunctionAspectsWithoutParametersAndReturnType_ReturnsNoErrorFromValidation() {
			var method = GetMethod("MethodWithoutParamsWithReturnType");
			var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestAspect2));

			AspectTypeMethodValidator.ValidateMethodAspect(aspect, method);
		}

		[TestMethod]
		[ExpectedException(typeof(AspectAnnotationException))]
		public void ParameterlessWithReturnTypeMethodWithOnMethodBoundaryAspectAttribute_DecoratedWithFunctionAspect_ThrowsAspectAnnotationException() {
			var method = GetMethod("MethodWithStringParamAndVoidReturnType");
			var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestAspect));

			AspectTypeMethodValidator.ValidateMethodAspect(aspect, method);
		}

		[TestMethod]
		[ExpectedException(typeof(AspectTypeMismatchException))]
		public void MethodWithOnMethodBoundaryAspectAttribute_DecoratedWithFunctionAspectThatHasDifferentReturnType_ThrowsAspectTypeMismatchException() {
			var method = GetMethod("MethodWithStringParamAndBoolReturnType");
			var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestAspect3));

			AspectTypeMethodValidator.ValidateMethodAspect(aspect, method);
		}

		[TestMethod]
		[ExpectedException(typeof(AspectTypeMismatchException))]
		public void MethodWithOnMethodBoundaryAspectAttribute_DecoratedWithFunctionAspectThatHasDifferentSetOfParameters_ThrowsAspectTypeMismatchException() {
			var method = GetMethod("MethodWithStringParamAndBoolReturnType");
			var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestAspect4));

			AspectTypeMethodValidator.ValidateMethodAspect(aspect, method);
		}

		[TestMethod]
		[ExpectedException(typeof(AspectAnnotationException))]
		public void ParameterslessMethodOnNoReturnTypeWithOnMethodBoundaryAspectAttribute_DecoratedWithFunctionAspect_ThrowsAspectAnnotationException() {
			var method = GetMethod("MethodWithoutParams");
			var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestAspect));

			AspectTypeMethodValidator.ValidateMethodAspect(aspect, method);
		}

		[TestMethod]
		[ExpectedException(typeof(AspectTypeMismatchException))]
		public void ParameterslessMethodWithOnMethodBoundaryAspectAttribute_DecoratedWithFunctionAspectThatHasAtLeastOneParameter_ThrowsAspectTypeMismatchException() {
			var method = GetMethod("MethodWithoutParamsWithReturnType");
			var aspect = new OnMethodBoundaryAspectAttribute(typeof(TestAspect));

			AspectTypeMethodValidator.ValidateMethodAspect(aspect, method);
		}

		[TestMethod]
		[ExpectedException(typeof(AdviceNotFoundException))]
		public void MethodWithOnMethodBoundaryAspectAttribute_DecoratedWithFunctionAspectThatHasNoAdvices_ThrowsAdviceNotFoundException() {
			var method = GetMethod("MethodWithStringParamAndBoolReturnType");
			var aspect = new OnMethodBoundaryAspectAttribute(typeof(NoAdviceAspect));

			AspectTypeMethodValidator.ValidateMethodAspect(aspect, method);
		}

		private static MethodInfo GetMethod(string name) {
			return typeof(Subject).GetMethod(name);
		}
	}
}
