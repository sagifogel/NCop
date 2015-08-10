using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.EventActionWithoutArgumentsAspectSubjects.Subjects;
using System;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class EventActionWithoutArgumentsAspectTest : AbstractAspectTest
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
        public void EventActionWithoutArguments_AnnotatedWithOnEventInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IEventActionWithoutArgumentsComposite>();
            var joinPoints = new EventInterceptionAspectOrderedJoinPoints();
            Action action = () => instance.Values.Add(AspectJoinPoints.Intercepted);

            instance.InterceptionAspect += action;
            instance.RaiseInterceptionAspect();
            instance.InterceptionAspect -= action;
            instance.RaiseInterceptionAspect();

            CollectionAssert.AreEqual(instance.Values, joinPoints);
        }

        [TestMethod]
        public void EventActionWithoutArguments_AnnotatedWithMultipleOnEventInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IEventActionWithoutArgumentsComposite>();
            var joinPoints = new MultipleEventInterceptionAspectOrderedJoinPoints();
            Action action = () => instance.Values.Add(AspectJoinPoints.Intercepted);

            instance.MultipleInterceptionAspects += action;
            instance.RaiseMultipleInterceptionAspect();
            instance.MultipleInterceptionAspects -= action;
            instance.RaiseMultipleInterceptionAspect();
            
            CollectionAssert.AreEqual(instance.Values, joinPoints);
        }

        [TestMethod]
        public void EventActionWithoutArguments_AnnotatedWithMultipleOnEventInterceptionAspectWhichCallsInvokeHanlder_IgnoresAllFollowingAspectsAndReturnsTheCorrectValue() {
            var instance = container.Resolve<IEventActionWithoutArgumentsComposite>();
            var joinPoints = new MultipleIgnoredEventInterceptionAspectOrderedJoinPoints();
            Action action = () => instance.Values.Add(AspectJoinPoints.Intercepted);

            instance.MultipleIgnoredInterceptionAspects += action;
            instance.RaiseMultipleIgnoredInterceptionAspects();
            instance.MultipleIgnoredInterceptionAspects -= action;
            instance.RaiseMultipleIgnoredInterceptionAspects();

            CollectionAssert.AreEqual(instance.Values, joinPoints);
        }
    }
}