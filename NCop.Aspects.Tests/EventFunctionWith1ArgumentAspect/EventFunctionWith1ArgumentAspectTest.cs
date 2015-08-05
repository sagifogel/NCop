using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.EventFunctionWith1ArgumentAspect.Subjects;
using System;
using System.Collections.Generic;
using NCop.Aspects.Tests.Extensions;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class EventFunctionWith1ArgumentAspectTest : AbstractAspectTest
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

        //[TestMethod]
        public void EventFunctionWith1Argument_AnnotatedWithOnEventInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            string result;
            var instance = container.Resolve<IEventFunctionWith1ArgumentComposite>();
            var list = new List<AspectJoinPoints>();
            var joinPoints = new EventInterceptionAspectOrderedJoinPoints();
            Func<List<AspectJoinPoints>, string> func = l => l.Stringify();

            instance.InterceptionAspect += func;
            result = instance.RaiseInterceptionAspect(list);
            instance.InterceptionAspect -= func;

            CollectionAssert.AreEqual(list, joinPoints);
            Assert.AreEqual(result, joinPoints.ToString());
        }
    }
}