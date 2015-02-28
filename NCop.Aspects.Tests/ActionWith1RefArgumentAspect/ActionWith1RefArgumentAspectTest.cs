using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.ActionWith1RefArgumentAspect.Subjects;
using System;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class ActionWith1RefArgumentAspectTest : AbstractAspectTest
    {
        private int i = 0;
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

        [TestInitialize()]
        public void InitializeAllprivateVariablesForEachTest() {
            i = 0;
        }

        [TestMethod]
        public void ActionWith1RefArgument_AnnotatedWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith1RefArgumentComposite>();

            instance.OnMethodBoundaryAspect(ref i);

            Assert.AreEqual(i, new OnMethodBoundaryAspectOrderedJoinPoints().Calculate());
        }

        [TestMethod]
        public void ActionWith1RefArgument_AnnotatedWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith1RefArgumentComposite>();

            instance.InterceptionAspect(ref i);
            Assert.AreEqual(i, new InterceptionAspectOrderedJoinPoints().Calculate());
        }

        [TestMethod]
        public void ActionWith1RefArgument_AnnotatedWithMultipleInterceptionAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith1RefArgumentComposite>();

            instance.MultipleInterceptionAspects(ref i);
            Assert.AreEqual(i, new MultipleInterceptionAspectOrderedJoinPoints().Calculate());
        }

        [TestMethod]
        public void ActionWith1RefArgument_AnnotatedWithMultipleOnMethodBoundaryAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith1RefArgumentComposite>();

            instance.MultipleOnMethodBoundaryAspects(ref i);

            Assert.AreEqual(i, new MultipleOnMethodBoundaryAspectOrderedJoinPoints().Calculate());
        }

        [TestMethod]
        public void ActionWith1RefArgument_AnnotatedWithAllAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith1RefArgumentComposite>();

            instance.AllAspectsStartingWithInterception(ref i);

            Assert.AreEqual(i, new AllAspectOrderedJoinPointsStartingWithInterceptionAspect().Calculate());
        }

        [TestMethod]
        public void ActionWith1RefArgument_AnnotatedWithAllAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith1RefArgumentComposite>();

            instance.AllAspectsStartingWithOnMethodBoundary(ref i);

            Assert.AreEqual(i, new AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect().Calculate());
        }

        [TestMethod]
        public void ActionWith1RefArgument_AnnotatedWithAlternateAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith1RefArgumentComposite>();

            instance.AlternatelAspectsStartingWithInterception(ref i);

            Assert.AreEqual(i, new AlternateAspectOrderedJoinPointsStartingWithInterceptionAspect().Calculate());
        }

        [TestMethod]
        public void ActionWith1RefArgument_AnnotatedWithAlternateAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith1RefArgumentComposite>();

            instance.AlternateAspectsStartingWithOnMethodBoundary(ref i);

            Assert.AreEqual(i, new AlternateAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect().Calculate());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ActionWith1RefArgument_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithDefaultFlowBehaviour_ThrowsException() {
            var instance = container.Resolve<IActionWith1RefArgumentComposite>();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i);
        }

        [TestMethod]
        public void ActionWith1RefArgument_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithContinueFlowBehaviour_OmitsTheOnSuccessAdvice() {
            var instance = container.Resolve<IActionWith1RefArgumentComposite>();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref i);

            Assert.AreEqual(i, new WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints().Calculate());
        }

        [TestMethod]
        public void ActionWith1RefArgument_AnnotatedWithATryFinallyOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocation_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith1RefArgumentComposite>();

            try {
                instance.TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i);
            }
            catch (Exception) {
                Assert.AreEqual(i, new TryFinallyWithExceptionOnMethodBoundaryAspectOrderedJoinPoints().Calculate());
            }
        }

        [TestMethod]
        public void ActionWith1RefArgument_OnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithoutTryFinally_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith1RefArgumentComposite>();

            try {
                instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref i);
            }
            catch (Exception) {
                Assert.AreEqual(i, new OnMethodBoundaryAspectWithExceptionAndWithoutTryFinallyOrderedJoinPoints().Calculate());
            }
        }

        [TestMethod]
        public void ActionWith1RefArgument_OnMethodBoundaryAspectWithOnlyOnEntryAdvice_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith1RefArgumentComposite>();

            instance.OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref i);
        
            Assert.AreEqual(i, new OnMethodBoundaryAspectWithOnlyOnEntryAdviceOrderedJoinPoints().Calculate());
        }

        [TestMethod]
        public void ActionWith1RefArgument_AnnotatedWithAllAspectsStartingFromInterceptionAspectThatCallsTheInvokeMethodOfTheArgs_ReturnsTheInMethodAdviceAndIgnoresAllOtherAspects() {
            var instance = container.Resolve<IActionWith1RefArgumentComposite>();

            instance.InterceptionAspectUsingInvoke(ref i);

            Assert.AreEqual(i, new InterceptionAspectUsingInvokeOrderedJoinPoints().Calculate());
        }
    }
}