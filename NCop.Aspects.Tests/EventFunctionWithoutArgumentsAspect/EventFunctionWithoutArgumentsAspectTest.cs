using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using NCop.Aspects.Tests.EventFunctionWithoutArgumentsAspectSubjects.Subjects;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class EventFunctionWithoutArgumentsAspectTest : AbstractAspectTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and EventFunctionality for the current test run.
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
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void EventFunctionWithoutArguments_AnnotatedWithOnEventInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            List<AspectJoinPoints> firstResult = null;
            List<AspectJoinPoints> secondResult = null;
            var instance = container.Resolve<IEventFunctionWithoutArgumentsComposite>();
            var joinPoints = new EventInterceptionAspectOrderedJoinPoints();
            Func<List<AspectJoinPoints>> func = () => {
                instance.Values.Add(AspectJoinPoints.Intercepted);

                return instance.Values;
            };

            instance.InterceptionAspect += func;
            firstResult = instance.RaiseInterceptionAspect();
            instance.InterceptionAspect -= func;
            secondResult = instance.RaiseInterceptionAspect();

            CollectionAssert.AreEqual(firstResult, joinPoints);
            CollectionAssert.AreEqual(secondResult, AspectOrderedJoinPoints.Empty);
        }

        [TestMethod]
        public void EventFunctionWith1Argument_AnnotatedWithMultipleOnEventInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            List<AspectJoinPoints> firstResult = null;
            List<AspectJoinPoints> secondResult = null;
            var instance = container.Resolve<IEventFunctionWithoutArgumentsComposite>();
            var joinPoints = new MultipleEventInterceptionAspectOrderedJoinPoints();
            Func<List<AspectJoinPoints>> func = () => {
                instance.Values.Add(AspectJoinPoints.Intercepted);

                return instance.Values;
            };

            instance.MultipleInterceptionAspects += func;
            firstResult = instance.RaiseMultipleInterceptionAspect();
            instance.MultipleInterceptionAspects -= func;
            secondResult = instance.RaiseMultipleInterceptionAspect();

            CollectionAssert.AreEqual(firstResult, joinPoints);
            CollectionAssert.AreEqual(secondResult, AspectOrderedJoinPoints.Empty);
        }

        [TestMethod]
        public void EventFunctionWith1Argument_AnnotatedWithMultipleOnEventInterceptionAspectWhichCallsInvokeHanlder_IgnoresAllFollowingAspectsAndReturnsTheCorrectValue() {
            List<AspectJoinPoints> firstResult = null;
            List<AspectJoinPoints> secondResult = null;
            var instance = container.Resolve<IEventFunctionWithoutArgumentsComposite>();
            var joinPoints = new MultipleIgnoredEventInterceptionAspectOrderedJoinPoints();
            Func<List<AspectJoinPoints>> func = () => {
                instance.Values.Add(AspectJoinPoints.Intercepted);

                return instance.Values;
            };

            instance.MultipleIgnoredInterceptionAspects += func;
            firstResult = instance.RaiseMultipleIgnoredInterceptionAspects();
            instance.MultipleIgnoredInterceptionAspects -= func;
            secondResult = instance.RaiseMultipleIgnoredInterceptionAspects();

            CollectionAssert.AreEqual(firstResult, joinPoints);
            CollectionAssert.AreEqual(secondResult, AspectOrderedJoinPoints.Empty);
        }
    }
}