using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.EventActionWith1ArgumentAspect.Subjects;
using NCop.Core.Extensions;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class EventActionWith1ArgumentAspectTest : AbstractAspectTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and EventActionality for the current test run.
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
        public void EventActionWith1Argument_AnnotatedWithOnEventInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var firstList = new List<AspectJoinPoints>();
            var secondList = new List<AspectJoinPoints>();
            var instance = container.Resolve<IEventActionWith1ArgumentComposite>();
            var joinPoints = new EventInterceptionAspectOrderedJoinPoints();
            Action<List<AspectJoinPoints>> action = l => instance.Values.Append(AspectJoinPoints.Intercepted);

            instance.InterceptionAspect += action;
            instance.RaiseInterceptionAspect(firstList);
            instance.InterceptionAspect -= action;
            instance.RaiseInterceptionAspect(secondList);

            CollectionAssert.AreEqual(firstList, new EventInterceptionInvokeAspectOrderedJoinPoints());
            CollectionAssert.AreEqual(secondList, AspectOrderedJoinPoints.Empty);
            CollectionAssert.AreEqual(instance.Values, joinPoints);
        }

        [TestMethod]
        public void EventActionWith1Argument_AnnotatedWithMultipleOnEventInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var firstList = new List<AspectJoinPoints>();
            var secondList = new List<AspectJoinPoints>();
            var instance = container.Resolve<IEventActionWith1ArgumentComposite>();
            var joinPoints = new MultipleEventInterceptionAspectOrderedJoinPoints();
            Action<List<AspectJoinPoints>> action = l => instance.Values.Append(AspectJoinPoints.Intercepted);
            
            instance.MultipleInterceptionAspects += action;
            instance.RaiseMultipleInterceptionAspect(firstList);
            instance.MultipleInterceptionAspects -= action;
            instance.RaiseMultipleInterceptionAspect(secondList);

            CollectionAssert.AreEqual(firstList, new EventMultipleInterceptionInvokeAspectOrderedJoinPoints());
            CollectionAssert.AreEqual(secondList, AspectOrderedJoinPoints.Empty);
            CollectionAssert.AreEqual(instance.Values, joinPoints);
        }

        [TestMethod]
        public void EventActionWith1Argument_AnnotatedWithMultipleOnEventInterceptionAspectWhichCallsInvokeHanlder_IgnoresAllFollowingAspectsAndReturnsTheCorrectValue() {
            var firstList = new List<AspectJoinPoints>();
            var secondList = new List<AspectJoinPoints>();
            var instance = container.Resolve<IEventActionWith1ArgumentComposite>();
            var joinPoints = new MultipleIgnoredEventInterceptionAspectOrderedJoinPoints();
            Action<List<AspectJoinPoints>> action = l => instance.Values.Append(AspectJoinPoints.Intercepted);

            instance.MultipleIgnoredInterceptionAspects += action;
            instance.RaiseMultipleIgnoredInterceptionAspects(firstList);
            instance.MultipleIgnoredInterceptionAspects -= action;
            instance.RaiseMultipleIgnoredInterceptionAspects(secondList);

            CollectionAssert.AreEqual(firstList, new EventInterceptionInvokeAspectOrderedJoinPoints());
            CollectionAssert.AreEqual(secondList, AspectOrderedJoinPoints.Empty);
            CollectionAssert.AreEqual(instance.Values, joinPoints);
        }
    }
}