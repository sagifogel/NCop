using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.ActionWith2ArgumentsAspect.Subjects;
using NCop.Composite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class ActionWith2ArgumentsAspectTest : AbstractAspectTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
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
        public void ActionWith2Arguments_AnnotatedWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith2ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var joinPoints = new OnMethodBoundaryAspectOrderedJoinPoints();

            instance.OnMethodBoundaryAspect(first, second);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.DoesNotContain(first, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(second, AspectJoinPoints.OnException);
        }

        [TestMethod]
        public void ActionWith2Arguments_AnnotatedWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith2ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var joinPoints = new InterceptionAspectOrderedJoinPoints();

            instance.InterceptionAspect(first, second);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
        }

        [TestMethod]
        public void ActionWith2Arguments_AnnotatedWithMultipleInterceptionAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith2ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var joinPoints = new MultipleInterceptionAspectOrderedJoinPoints();

            instance.MultipleInterceptionAspects(first, second);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
        }

        [TestMethod]
        public void ActionWith2Arguments_AnnotatedWithMultipleOnMethodBoundaryAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith2ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var joinPoints = new MultipleOnMethodBoundaryAspectOrderedJoinPoints();

            instance.MultipleOnMethodBoundaryAspects(first, second);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.DoesNotContain(first, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(second, AspectJoinPoints.OnException);
        }

        [TestMethod]
        public void ActionWith2Arguments_AnnotatedWithAllAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith2ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithInterceptionAspect();

            instance.AllAspectsStartingWithInterception(first, second);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
        }

        [TestMethod]
        public void ActionWith2Arguments_AnnotatedWithAllAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith2ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect();

            instance.AllAspectsStartingWithOnMethodBoundary(first, second);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.DoesNotContain(first, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(second, AspectJoinPoints.OnException);
        }

        [TestMethod]
        public void ActionWith2Arguments_AnnotatedWithAlternateAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith2ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithInterceptionAspect();

            instance.AlternatelAspectsStartingWithInterception(first, second);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
        }

        [TestMethod]
        public void ActionWith2Arguments_AnnotatedWithAlternateAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith2ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect();

            instance.AlternateAspectsStartingWithOnMethodBoundary(first, second);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.DoesNotContain(first, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(second, AspectJoinPoints.OnException);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ActionWith2Arguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithDefaultFlowBehaviour_ThrowsException() {
            var instance = container.Resolve<IActionWith2ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var joinPoints = new MultipleOnMethodBoundaryAspectOrderedJoinPoints();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second);
        }

        [TestMethod]
        public void ActionWith2Arguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithContinueFlowBehaviour_OmitsTheOnSuccessAdvice() {
            var instance = container.Resolve<IActionWith2ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var joinPoints = new WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(first, second);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
        }

        [TestMethod]
        public void ActionWith2Arguments_AnnotatedWithATryFinallyOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocation_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith2ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var joinPoints = new TryFinallyWithExceptionOnMethodBoundaryAspectOrderedJoinPoints();

            try {
                instance.TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second);
            }
            catch (Exception) {
                CollectionAssert.AreEqual(first, joinPoints);
                CollectionAssert.AreEqual(second, joinPoints);
            }
        }

        [TestMethod]
        public void ActionWith2Arguments_OnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithoutTryFinally_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith2ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var joinPoints = new OnMethodBoundaryAspectWithExceptionAndWithoutTryFinallyOrderedJoinPoints();

            try {
                instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(first, second);
            }
            catch (Exception) {
                CollectionAssert.AreEqual(first, joinPoints);
                CollectionAssert.AreEqual(second, joinPoints);
            }
        }

        [TestMethod]
        public void ActionWith2Arguments_OnMethodBoundaryAspectWithOnlyOnEntryAdvice_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith2ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var joinPoints = new OnMethodBoundaryAspectWithOnlyOnEntryAdviceOrderedJoinPoints();

            instance.OnMethodBoundaryAspectWithOnlyOnEntryAdvide(first, second);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
        }
    }
}