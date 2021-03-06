﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.EventFunctionWith6ArgumentsAspect.Subjects;
using NCop.Aspects.Tests.Extensions;
using NCop.Core.Extensions;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class EventFunctionWith6ArgumentsAspectTest : AbstractAspectTest
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
        public void EventFunctionWith6Arguments_AnnotatedWithOnEventInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            string firstResult = null;
            string secondResult = null;
            var firstArg1List = new List<AspectJoinPoints>();
            var firstArg2List = new List<AspectJoinPoints>();
            var firstArg3List = new List<AspectJoinPoints>();
            var firstArg4List = new List<AspectJoinPoints>();
            var firstArg5List = new List<AspectJoinPoints>();
            var firstArg6List = new List<AspectJoinPoints>();
            var secondArg1List = new List<AspectJoinPoints>();
            var secondArg2List = new List<AspectJoinPoints>();
            var secondArg3List = new List<AspectJoinPoints>();
            var secondArg4List = new List<AspectJoinPoints>();
            var secondArg5List = new List<AspectJoinPoints>();
            var secondArg6List = new List<AspectJoinPoints>();
            var instance = container.Resolve<IEventFunctionWith6ArgumentsComposite>();
            var joinPoints = new EventInterceptionAspectOrderedJoinPoints();
            Func<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> func = (l1, l2, l3, l4, l5, l6) => instance.Values.Append(AspectJoinPoints.Intercepted).ToString();

            instance.InterceptionAspect += func;
            firstResult = instance.RaiseInterceptionAspect(firstArg1List, firstArg2List, firstArg3List, firstArg4List, firstArg5List, firstArg6List);
            instance.InterceptionAspect -= func;
            secondResult = instance.RaiseInterceptionAspect(secondArg1List, secondArg2List, secondArg3List, secondArg4List, secondArg5List, secondArg6List);

            CollectionAssertExt.AreAllEqual(new EventInterceptionInvokeAspectOrderedJoinPoints(), firstArg1List, firstArg2List, firstArg3List, firstArg4List, firstArg5List, firstArg6List);
            CollectionAssertExt.AreAllEqual(AspectOrderedJoinPoints.Empty, secondArg1List, secondArg2List, secondArg3List, secondArg4List, secondArg5List, secondArg6List);
            CollectionAssert.AreEqual(instance.Values, joinPoints);
            Assert.AreEqual(firstResult, AspectJoinPoints.Intercepted.ToString());
            Assert.AreEqual(secondResult, AspectJoinPoints.NoEvent.ToString());
        }

        [TestMethod]
        public void EventFunctionWith6Arguments_AnnotatedWithMultipleOnEventInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            string firstResult = null;
            string secondResult = null;
            var firstArg1List = new List<AspectJoinPoints>();
            var firstArg2List = new List<AspectJoinPoints>();
            var firstArg3List = new List<AspectJoinPoints>();
            var firstArg4List = new List<AspectJoinPoints>();
            var firstArg5List = new List<AspectJoinPoints>();
            var firstArg6List = new List<AspectJoinPoints>();
            var secondArg1List = new List<AspectJoinPoints>();
            var secondArg2List = new List<AspectJoinPoints>();
            var secondArg3List = new List<AspectJoinPoints>();
            var secondArg4List = new List<AspectJoinPoints>();
            var secondArg5List = new List<AspectJoinPoints>();
            var secondArg6List = new List<AspectJoinPoints>();
            var instance = container.Resolve<IEventFunctionWith6ArgumentsComposite>();
            var joinPoints = new MultipleEventInterceptionAspectOrderedJoinPoints();
            Func<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> func = (l1, l2, l3, l4, l5, l6) => instance.Values.Append(AspectJoinPoints.Intercepted).ToString();

            instance.MultipleInterceptionAspects += func;
            firstResult = instance.RaiseMultipleInterceptionAspect(firstArg1List, firstArg2List, firstArg3List, firstArg4List, firstArg5List, firstArg6List);
            instance.MultipleInterceptionAspects -= func;
            secondResult = instance.RaiseMultipleInterceptionAspect(secondArg1List, secondArg2List, secondArg3List, secondArg4List, secondArg5List, secondArg6List);

            CollectionAssertExt.AreAllEqual(new EventMultipleInterceptionInvokeAspectOrderedJoinPoints(), firstArg1List, firstArg2List, firstArg3List, firstArg4List, firstArg5List, firstArg6List);
            CollectionAssertExt.AreAllEqual(AspectOrderedJoinPoints.Empty, secondArg1List, secondArg2List, secondArg3List, secondArg4List, secondArg5List, secondArg6List);
            CollectionAssert.AreEqual(instance.Values, joinPoints);
            Assert.AreEqual(firstResult, AspectJoinPoints.Intercepted.ToString());
            Assert.AreEqual(secondResult, AspectJoinPoints.NoEvent.ToString());
        }

        [TestMethod]
        public void EventFunctionWith6Arguments_AnnotatedWithMultipleOnEventInterceptionAspectWhichCallsInvokeHanlder_IgnoresAllFollowingAspectsAndReturnsTheCorrectValue() {
            string firstResult = null;
            string secondResult = null;
            var firstArg1List = new List<AspectJoinPoints>();
            var firstArg2List = new List<AspectJoinPoints>();
            var firstArg3List = new List<AspectJoinPoints>();
            var firstArg4List = new List<AspectJoinPoints>();
            var firstArg5List = new List<AspectJoinPoints>();
            var firstArg6List = new List<AspectJoinPoints>();
            var secondArg1List = new List<AspectJoinPoints>();
            var secondArg2List = new List<AspectJoinPoints>();
            var secondArg3List = new List<AspectJoinPoints>();
            var secondArg4List = new List<AspectJoinPoints>();
            var secondArg5List = new List<AspectJoinPoints>();
            var secondArg6List = new List<AspectJoinPoints>();
            var instance = container.Resolve<IEventFunctionWith6ArgumentsComposite>();
            var joinPoints = new MultipleIgnoredEventInterceptionAspectOrderedJoinPoints();
            Func<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> func = (l1, l2, l3, l4, l5, l6) => {
                return instance.Values.Append(AspectJoinPoints.Intercepted).ToString();
            };

            instance.MultipleIgnoredInterceptionAspects += func;
            firstResult = instance.RaiseMultipleIgnoredInterceptionAspects(firstArg1List, firstArg2List, firstArg3List, firstArg4List, firstArg5List, firstArg6List);
            instance.MultipleIgnoredInterceptionAspects -= func;
            secondResult = instance.RaiseMultipleIgnoredInterceptionAspects(secondArg1List, secondArg2List, secondArg3List, secondArg4List, secondArg5List, secondArg6List);

            CollectionAssertExt.AreAllEqual(new EventInterceptionInvokeAspectOrderedJoinPoints(), firstArg1List, firstArg2List, firstArg3List, firstArg4List, firstArg5List, firstArg6List);
            CollectionAssertExt.AreAllEqual(AspectOrderedJoinPoints.Empty, secondArg1List, secondArg2List, secondArg3List, secondArg4List, secondArg5List, secondArg6List);
            CollectionAssert.AreEqual(instance.Values, joinPoints);
            Assert.AreEqual(firstResult, AspectJoinPoints.Intercepted.ToString());
            Assert.AreEqual(secondResult, AspectJoinPoints.NoEvent.ToString());
        }
    }
}