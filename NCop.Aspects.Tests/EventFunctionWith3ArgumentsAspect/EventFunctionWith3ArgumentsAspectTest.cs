using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.EventFunctionWith3ArgumentsAspect.Subjects;
using NCop.Aspects.Tests.Extensions;
using NCop.Core.Extensions;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class EventFunctionWith3ArgumentsAspectTest : AbstractAspectTest
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
        public void EventFunctionWith3Arguments_AnnotatedWithOnEventInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            string firstResult = null;
            string secondResult = null;
            var firstArg1List = new List<AspectJoinPoints>();
            var firstArg2List = new List<AspectJoinPoints>();
            var firstArg3List = new List<AspectJoinPoints>();
            var secondArg1List = new List<AspectJoinPoints>();
            var secondArg2List = new List<AspectJoinPoints>();
            var secondArg3List = new List<AspectJoinPoints>();
            var instance = container.Resolve<IEventFunctionWith3ArgumentsComposite>();
            var joinPoints = new EventInterceptionAspectOrderedJoinPoints();
            Func<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> func = (l1, l2, l3) => instance.Values.Append(AspectJoinPoints.Intercepted).ToString();

            instance.InterceptionAspect += func;
            firstResult = instance.RaiseInterceptionAspect(firstArg1List, firstArg2List, firstArg3List);
            instance.InterceptionAspect -= func;
            secondResult = instance.RaiseInterceptionAspect(secondArg1List, secondArg2List, secondArg3List);

            CollectionAssertExt.AreAllEqual(new EventInterceptionInvokeAspectOrderedJoinPoints(), firstArg1List, firstArg2List, firstArg3List);
            CollectionAssertExt.AreAllEqual(AspectOrderedJoinPoints.Empty, secondArg1List, secondArg2List, secondArg3List);
            CollectionAssert.AreEqual(instance.Values, joinPoints);
            Assert.AreEqual(firstResult, AspectJoinPoints.Intercepted.ToString());
            Assert.AreEqual(secondResult, AspectJoinPoints.NoEvent.ToString());
        }

        [TestMethod]
        public void EventFunctionWith3Arguments_AnnotatedWithMultipleOnEventInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            string firstResult = null;
            string secondResult = null;
            var firstArg1List = new List<AspectJoinPoints>();
            var firstArg2List = new List<AspectJoinPoints>();
            var firstArg3List = new List<AspectJoinPoints>();
            var secondArg1List = new List<AspectJoinPoints>();
            var secondArg2List = new List<AspectJoinPoints>();
            var secondArg3List = new List<AspectJoinPoints>();
            var instance = container.Resolve<IEventFunctionWith3ArgumentsComposite>();
            var joinPoints = new MultipleEventInterceptionAspectOrderedJoinPoints();
            Func<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> func = (l1, l2, l3) => instance.Values.Append(AspectJoinPoints.Intercepted).ToString();

            instance.MultipleInterceptionAspects += func;
            firstResult = instance.RaiseMultipleInterceptionAspect(firstArg1List, firstArg2List, firstArg3List);
            instance.MultipleInterceptionAspects -= func;
            secondResult = instance.RaiseMultipleInterceptionAspect(secondArg1List, secondArg2List, secondArg3List);

            CollectionAssertExt.AreAllEqual(new EventMultipleInterceptionInvokeAspectOrderedJoinPoints(), firstArg1List, firstArg2List, firstArg3List);
            CollectionAssertExt.AreAllEqual(AspectOrderedJoinPoints.Empty, secondArg1List, secondArg2List, secondArg3List);
            CollectionAssert.AreEqual(instance.Values, joinPoints);
            Assert.AreEqual(firstResult, AspectJoinPoints.Intercepted.ToString());
            Assert.AreEqual(secondResult, AspectJoinPoints.NoEvent.ToString());
        }

        [TestMethod]
        public void EventFunctionWith3Arguments_AnnotatedWithMultipleOnEventInterceptionAspectWhichCallsInvokeHanlder_IgnoresAllFollowingAspectsAndReturnsTheCorrectValue() {
            string firstResult = null;
            string secondResult = null;
            var firstArg1List = new List<AspectJoinPoints>();
            var firstArg2List = new List<AspectJoinPoints>();
            var firstArg3List = new List<AspectJoinPoints>();
            var secondArg1List = new List<AspectJoinPoints>();
            var secondArg2List = new List<AspectJoinPoints>();
            var secondArg3List = new List<AspectJoinPoints>();
            var instance = container.Resolve<IEventFunctionWith3ArgumentsComposite>();
            var joinPoints = new MultipleIgnoredEventInterceptionAspectOrderedJoinPoints();
            Func<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> func = (l1, l2, l3) => {
                return instance.Values.Append(AspectJoinPoints.Intercepted).ToString();
            };

            instance.MultipleIgnoredInterceptionAspects += func;
            firstResult = instance.RaiseMultipleIgnoredInterceptionAspects(firstArg1List, firstArg2List, firstArg3List);
            instance.MultipleIgnoredInterceptionAspects -= func;
            secondResult = instance.RaiseMultipleIgnoredInterceptionAspects(secondArg1List, secondArg2List, secondArg3List);

            CollectionAssertExt.AreAllEqual(new EventInterceptionInvokeAspectOrderedJoinPoints(), firstArg1List, firstArg2List, firstArg3List);
            CollectionAssertExt.AreAllEqual(AspectOrderedJoinPoints.Empty, secondArg1List, secondArg2List, secondArg3List);
            CollectionAssert.AreEqual(instance.Values, joinPoints);
            Assert.AreEqual(firstResult, AspectJoinPoints.Intercepted.ToString());
            Assert.AreEqual(secondResult, AspectJoinPoints.NoEvent.ToString());
        }
    }
}