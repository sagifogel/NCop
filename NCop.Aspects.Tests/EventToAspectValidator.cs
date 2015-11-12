using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Engine;
using NCop.Aspects.Exceptions;
using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class EventToAspectValidator
    {
        public class TestInterceptionAspectWithNewEventOfOnInvokeThatHasAReturnType : EventActionInterceptionAspect
        {
            public new string OnInvokeHandler(EventActionInterceptionArgs args) {
                base.OnInvokeHandler(args);

                return string.Empty;
            }
        }

        public class TestEventFunctionAspectWithNewEventOfOnAddHandlerThatHasAReturnType : EventActionInterceptionAspect
        {
            public new string OnAddHandler(EventActionInterceptionArgs args) {
                base.OnInvokeHandler(args);

                return string.Empty;
            }
        }

        public class TestEventFunctionAspectWithNewEventOfOnRemoveHandlerThatHasAReturnType : EventActionInterceptionAspect
        {
            public new string OnRemoveHandler(EventActionInterceptionArgs args) {
                base.OnRemoveHandler(args);

                return string.Empty;
            }
        }

        public class TestEventInterceptionAspectWithNewEventOfOnInvokeThatHasMoreThenOneArgument : EventActionInterceptionAspect
        {
            public new void OnInvokeHandler(EventActionInterceptionArgs args, string s) {
                base.OnInvokeHandler(args);
            }
        }

        public class TestEventInterceptionAspectWithNewEventOfOnAddHandlerThatHasMoreThenOneArgument : EventActionInterceptionAspect
        {
            public new void OnAddHandler(EventActionInterceptionArgs args, string s) {
                base.OnAddHandler(args);
            }
        }

        public class TestEventInterceptionAspectWithNewEventOfOnRemoveHandlerThatHasMoreThenOneArgument : EventActionInterceptionAspect
        {
            public new void OnRemoveHandler(EventActionInterceptionArgs args, string s) {
                base.OnRemoveHandler(args);
            }
        }

        public class TestEventFunctionInterceptionAspect : EventFunctionInterceptionAspect<int>
        {
            public override void OnInvokeHandler(EventFunctionInterceptionArgs<int> args) {
            }
        }

        public class TestInterceptionAspect : FunctionInterceptionAspect<string, bool>
        {
            public override void OnInvoke(FunctionInterceptionArgs<string, bool> args) {
                base.OnInvoke(args);
            }
        }

        public class TestAspect : EventFunctionInterceptionAspect<string, bool>
        {
            public override void OnInvokeHandler(EventFunctionInterceptionArgs<string, bool> args) {
            }
        }

        public class TestAspect2 : EventFunctionInterceptionAspect<bool>
        {
            public override void OnInvokeHandler(EventFunctionInterceptionArgs<bool> args) {
            }
        }

        public class TestAspect3 : EventFunctionInterceptionAspect<string, string>
        {
            public override void OnInvokeHandler(EventFunctionInterceptionArgs<string, string> args) {
            }
        }

        public class TestAspect4 : EventFunctionInterceptionAspect<int, bool>
        {
            public override void OnInvokeHandler(EventFunctionInterceptionArgs<int, bool> args) {
            }
        }

        public class EventAction : EventActionInterceptionAspect
        {
            public override void OnInvokeHandler(EventActionInterceptionArgs args) {
            }
        }

        public class NoAdviceAspect : EventFunctionInterceptionAspect<string, string>
        {
        }

        public class Subject
        {
            public event Action EventWithoutParams;
            public event Action<int> EventWithIntParamAndNoReturnType;
            public event Func<bool> EventWithoutParamsWithBoolReturnType;
            public event Action<string> EventWithStringParamAndVoidReturnType;
            public event Func<string, bool> EventWithStringParamAndBoolReturnType;
        }

        private static EventInfo GetEvent(string name) {
            return typeof(Subject).GetEvent(name);
        }

        [TestMethod]
        public void EventWithStringParamAndBoolReturnType_DecoratedWithMatchedEventInterceptionAspectAttribute_ReturnsNoErrorFromValidation() {
            var Event = GetEvent("EventWithStringParamAndBoolReturnType");
            var aspect = new EventInterceptionAspectAttribute(typeof(TestAspect));

            AspectTypeValidator.ValidateEventAspect(aspect, Event);
        }

        [TestMethod]
        public void ParameterlessEventWithReturnType_DecoratedWithMatchedFunctionAspectsWithoutParametersAndReturnType_ReturnsNoErrorFromValidation() {
            var Event = GetEvent("EventWithoutParamsWithBoolReturnType");
            var aspect = new EventInterceptionAspectAttribute(typeof(TestAspect2));

            AspectTypeValidator.ValidateEventAspect(aspect, Event);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectAnnotationException))]
        public void EventInterceptionAspectAttribute_GivenAnInterceptionAspectTypeAsAnArgument_ThrowsAspectAnnotationException() {
            var Event = GetEvent("EventWithStringParamAndBoolReturnType");
            var aspect = new EventInterceptionAspectAttribute(typeof(TestInterceptionAspect));

            AspectTypeValidator.ValidateEventAspect(aspect, Event);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectAnnotationException))]
        public void EventWithoutReturnType_DecoratedWithEventInterceptionAspectAttribute_ThrowsAspectAnnotationException() {
            var Event = GetEvent("EventWithStringParamAndVoidReturnType");
            var aspect = new EventInterceptionAspectAttribute(typeof(TestAspect));

            AspectTypeValidator.ValidateEventAspect(aspect, Event);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void EventWithAReturnType_DecoratedWithFunctionAspectThatHasDifferentReturnType_ThrowsAspectTypeMismatchException() {
            var Event = GetEvent("EventWithStringParamAndBoolReturnType");
            var aspect = new EventInterceptionAspectAttribute(typeof(TestAspect3));

            AspectTypeValidator.ValidateEventAspect(aspect, Event);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectAnnotationException))]
        public void EventWithAReturnType_DecoratedWithEventActionAspect_ThrowsAspectTypeMismatchException() {
            var Event = GetEvent("EventWithStringParamAndBoolReturnType");
            var aspect = new EventInterceptionAspectAttribute(typeof(EventAction));

            AspectTypeValidator.ValidateEventAspect(aspect, Event);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void EventWithOneParemeterAndReturnType_DecoratedWithEventFunctionAspectThatHasDifferentSetOfParameters_ThrowsAspectTypeMismatchException() {
            var Event = GetEvent("EventWithStringParamAndBoolReturnType");
            var aspect = new EventInterceptionAspectAttribute(typeof(TestAspect4));

            AspectTypeValidator.ValidateEventAspect(aspect, Event);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectAnnotationException))]
        public void ParameterslessEventAndNoReturnType_DecoratedWithFunctionAspect_ThrowsAspectAnnotationException() {
            var Event = GetEvent("EventWithoutParams");
            var aspect = new EventInterceptionAspectAttribute(typeof(TestAspect));

            AspectTypeValidator.ValidateEventAspect(aspect, Event);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void ParameterslessEventWithReturnType_DecoratedWithFunctionAspectThatHasAtLeastOneParameter_ThrowsAspectTypeMismatchException() {
            var Event = GetEvent("EventWithoutParamsWithBoolReturnType");
            var aspect = new EventInterceptionAspectAttribute(typeof(TestAspect));

            AspectTypeValidator.ValidateEventAspect(aspect, Event);
        }

        [TestMethod]
        [ExpectedException(typeof(AdviceNotFoundException))]
        public void Event_DecoratedWithFunctionAspectThatHasNoAdvices_ThrowsAdviceNotFoundException() {
            var Event = GetEvent("EventWithStringParamAndBoolReturnType");
            var aspect = new EventInterceptionAspectAttribute(typeof(NoAdviceAspect));

            AspectTypeValidator.ValidateEventAspect(aspect, Event);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void EventWithoutReturnType_DecoratedWithEventActionInterceptionAspectWithNewEventOfOnInvokeThatHasAReturnType_ThrowsAspectTypeMismatchException() {
            var Event = GetEvent("EventWithoutParams");
            var aspect = new EventInterceptionAspectAttribute(typeof(TestInterceptionAspectWithNewEventOfOnInvokeThatHasAReturnType));

            AspectTypeValidator.ValidateEventAspect(aspect, Event);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void EventWithoutReturn_DecoratedWithOnActionBoundaryAspectWithNewEventOfOnAddHandlerThatHasAReturnType_ThrowsAspectTypeMismatchException() {
            var Event = GetEvent("EventWithoutParams");
            var aspect = new EventInterceptionAspectAttribute(typeof(TestEventFunctionAspectWithNewEventOfOnAddHandlerThatHasAReturnType));

            AspectTypeValidator.ValidateEventAspect(aspect, Event);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void EventWithoutReturn_DecoratedWithOnActionBoundaryAspectWithNewEventOfOnRemoveHandlerThatHasAReturnType_ThrowsAspectTypeMismatchException() {
            var Event = GetEvent("EventWithoutParams");
            var aspect = new EventInterceptionAspectAttribute(typeof(TestEventFunctionAspectWithNewEventOfOnRemoveHandlerThatHasAReturnType));

            AspectTypeValidator.ValidateEventAspect(aspect, Event);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void EventWithoutReturnType_DecoratedWithActionInterceptionAspectWithNewEventOfOnInvokeThatHasMoreThenOneArgument_ThrowsAspectTypeMismatchException() {
            var Event = GetEvent("EventWithoutParams");
            var aspect = new EventInterceptionAspectAttribute(typeof(TestEventInterceptionAspectWithNewEventOfOnInvokeThatHasMoreThenOneArgument));

            AspectTypeValidator.ValidateEventAspect(aspect, Event);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void EventWithoutReturn_DecoratedWithOnActionBoundaryAspectWithNewEventOfOnRemoveThatHasMoreThenOneArgument_ThrowsAspectTypeMismatchException() {
            var Event = GetEvent("EventWithoutParams");
            var aspect = new EventInterceptionAspectAttribute(typeof(TestEventInterceptionAspectWithNewEventOfOnRemoveHandlerThatHasMoreThenOneArgument));

            AspectTypeValidator.ValidateEventAspect(aspect, Event);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectTypeMismatchException))]
        public void EventWithoutReturn_DecoratedWithOnActionBoundaryAspectWithNewEventOfOnAddHandlerThatHasMoreThenOneArgument_ThrowsAspectTypeMismatchException() {
            var Event = GetEvent("EventWithoutParams");
            var aspect = new EventInterceptionAspectAttribute(typeof(TestEventInterceptionAspectWithNewEventOfOnAddHandlerThatHasMoreThenOneArgument));

            AspectTypeValidator.ValidateEventAspect(aspect, Event);
        }

        [TestMethod]
        [ExpectedException(typeof(AspectAnnotationException))]
        public void EventWithOneParameterAndNoReturnType_DecoratedWithOnFunctionInterceptionAspectWithOneAReturnTypeThatIsTheSameUnderlyingTypeAsTheParameterOfTheEvent_ThrowsAspectAnnotationException() {
            var Event = GetEvent("EventWithIntParamAndNoReturnType");
            var aspect = new EventInterceptionAspectAttribute(typeof(TestEventFunctionInterceptionAspect));

            AspectTypeValidator.ValidateEventAspect(aspect, Event);
        }
    }
}
