using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using NCop.Aspects.Tests.EventFunctionWith2ArgumentAspect.Subjects;
using NCop.Core.Extensions;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class EventFunctionWith2ArgumentsAspectTest : AbstractAspectTest
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
        public void EventFunctionWith2Arguments_AnnotatedWithOnEventInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            string firstResult = null;
            string secondResult = null;
            var firstArg1List = new List<AspectJoinPoints>();
            var firstArg2List = new List<AspectJoinPoints>();
            var secondArg1List = new List<AspectJoinPoints>();
            var secondArg2List = new List<AspectJoinPoints>(); 
            var instance = container.Resolve<IEventFunctionWith2ArgumentComposite>();
            var joinPoints = new EventInterceptionAspectOrderedJoinPoints();
            Func<List<AspectJoinPoints>, List<AspectJoinPoints>, string> func = (l1, l2) => instance.Values.Append(AspectJoinPoints.Intercepted).ToString();
            var firstList = new List<AspectJoinPoints>();
            var secondList = new List<AspectJoinPoints>();

            instance.InterceptionAspect += func;
            firstResult = instance.RaiseInterceptionAspect(firstArg1List, firstArg2List);
            instance.InterceptionAspect -= func;
            secondResult = instance.RaiseInterceptionAspect(secondArg1List, secondArg2List);

            CollectionAssert.AreEqual(firstArg1List, new EventInterceptionInvokeAspectOrderedJoinPoints());
            CollectionAssert.AreEqual(firstArg1List, firstArg2List);
            CollectionAssert.AreEqual(secondArg1List, AspectOrderedJoinPoints.Empty);
            CollectionAssert.AreEqual(secondArg1List, secondArg2List);
            CollectionAssert.AreEqual(instance.Values, joinPoints);
            Assert.AreEqual(firstResult, AspectJoinPoints.Intercepted.ToString());
            Assert.AreEqual(secondResult, AspectJoinPoints.NoEvent.ToString());
        }

        [TestMethod]
        public void EventFunctionWith2Arguments_AnnotatedWithMultipleOnEventInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            string firstResult = null;
            string secondResult = null;
            var firstArg1List = new List<AspectJoinPoints>();
            var firstArg2List = new List<AspectJoinPoints>();
            var secondArg1List = new List<AspectJoinPoints>();
            var secondArg2List = new List<AspectJoinPoints>(); 
            var instance = container.Resolve<IEventFunctionWith2ArgumentComposite>();
            var joinPoints = new MultipleEventInterceptionAspectOrderedJoinPoints();
            Func<List<AspectJoinPoints>, List<AspectJoinPoints>, string> func = (l1, l2) => instance.Values.Append(AspectJoinPoints.Intercepted).ToString();

            instance.MultipleInterceptionAspects += func;
            firstResult = instance.RaiseMultipleInterceptionAspect(firstArg1List, firstArg2List);
            instance.MultipleInterceptionAspects -= func;
            secondResult = instance.RaiseMultipleInterceptionAspect(secondArg1List, secondArg2List);

            CollectionAssert.AreEqual(firstArg1List, new EventMultipleInterceptionInvokeAspectOrderedJoinPoints());
            CollectionAssert.AreEqual(firstArg1List, firstArg2List);
            CollectionAssert.AreEqual(secondArg1List, AspectOrderedJoinPoints.Empty);
            CollectionAssert.AreEqual(secondArg1List, secondArg2List);
            CollectionAssert.AreEqual(instance.Values, joinPoints);
            Assert.AreEqual(firstResult, AspectJoinPoints.Intercepted.ToString());
            Assert.AreEqual(secondResult, AspectJoinPoints.NoEvent.ToString());
        }

        [TestMethod]
        public void EventFunctionWith2Arguments_AnnotatedWithMultipleOnEventInterceptionAspectWhichCallsInvokeHanlder_IgnoresAllFollowingAspectsAndReturnsTheCorrectValue() {
            string firstResult = null;
            string secondResult = null;
            var firstArg1List = new List<AspectJoinPoints>();
            var firstArg2List = new List<AspectJoinPoints>();
            var secondArg1List = new List<AspectJoinPoints>();
            var secondArg2List = new List<AspectJoinPoints>(); 
            var instance = container.Resolve<IEventFunctionWith2ArgumentComposite>();
            var joinPoints = new MultipleIgnoredEventInterceptionAspectOrderedJoinPoints();
            Func<List<AspectJoinPoints>, List<AspectJoinPoints>, string> func = (l1, l2) => {
                return instance.Values.Append(AspectJoinPoints.Intercepted).ToString();
            };

            instance.MultipleIgnoredInterceptionAspects += func;
            firstResult = instance.RaiseMultipleIgnoredInterceptionAspects(firstArg1List, firstArg2List);
            instance.MultipleIgnoredInterceptionAspects -= func;
            secondResult = instance.RaiseMultipleIgnoredInterceptionAspects(secondArg1List, secondArg2List);

            CollectionAssert.AreEqual(firstArg1List, new EventInterceptionInvokeAspectOrderedJoinPoints());
            CollectionAssert.AreEqual(firstArg1List, firstArg2List);
            CollectionAssert.AreEqual(secondArg1List, AspectOrderedJoinPoints.Empty);
            CollectionAssert.AreEqual(secondArg1List, secondArg2List); 
            CollectionAssert.AreEqual(instance.Values, joinPoints);
            Assert.AreEqual(firstResult, AspectJoinPoints.Intercepted.ToString());
            Assert.AreEqual(secondResult, AspectJoinPoints.NoEvent.ToString());
        }
    }
}