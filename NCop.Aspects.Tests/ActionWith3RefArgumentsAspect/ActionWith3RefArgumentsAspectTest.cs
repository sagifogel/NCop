using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.ActionWith3RefArgumentsAspect.Subjects;
using NCop.Composite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class ActionWith3RefArgumentsAspectTest : AbstractAspectTest
    {
        private int i = 0;
        private int j = 0;
        private int k = 0;
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
            i = j = k = 0;
        }

        [TestMethod]
        public void ActionWith3RefArguments_AnnotatedWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith3RefArgumentsComposite>();
            var joinPoints = new OnMethodBoundaryAspectOrderedJoinPoints().Calculate();

            instance.OnMethodBoundaryAspect(ref i, ref j, ref k);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
        }

        [TestMethod]
        public void ActionWith3RefArguments_AnnotatedWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith3RefArgumentsComposite>();
            var joinPoints = new InterceptionAspectOrderedJoinPoints().Calculate();

            instance.InterceptionAspect(ref i, ref j, ref k);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
        }

        [TestMethod]
        public void ActionWith3RefArguments_AnnotatedWithMultipleInterceptionAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith3RefArgumentsComposite>();
            var joinPoints = new MultipleInterceptionAspectOrderedJoinPoints().Calculate();

            instance.MultipleInterceptionAspects(ref i, ref j, ref k);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
        }

        [TestMethod]
        public void ActionWith3RefArguments_AnnotatedWithMultipleOnMethodBoundaryAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith3RefArgumentsComposite>();
            var joinPoints = new MultipleOnMethodBoundaryAspectOrderedJoinPoints().Calculate();

            instance.MultipleOnMethodBoundaryAspects(ref i, ref j, ref k);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
        }

        [TestMethod]
        public void ActionWith3RefArguments_AnnotatedWithAllAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith3RefArgumentsComposite>();
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithInterceptionAspect().Calculate();

            instance.AllAspectsStartingWithInterception(ref i, ref j, ref k);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
        }

        [TestMethod]
        public void ActionWith3RefArguments_AnnotatedWithAllAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith3RefArgumentsComposite>();
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect().Calculate();

            instance.AllAspectsStartingWithOnMethodBoundary(ref i, ref j, ref k);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
        }

        [TestMethod]
        public void ActionWith3RefArguments_AnnotatedWithAlternateAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith3RefArgumentsComposite>();
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithInterceptionAspect().Calculate();

            instance.AlternatelAspectsStartingWithInterception(ref i, ref j, ref k);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
        }

        [TestMethod]
        public void ActionWith3RefArguments_AnnotatedWithAlternateAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith3RefArgumentsComposite>();
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect().Calculate();

            instance.AlternateAspectsStartingWithOnMethodBoundary(ref i, ref j, ref k);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ActionWith3RefArguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithDefaultFlowBehaviour_ThrowsException() {
            var instance = container.Resolve<IActionWith3RefArgumentsComposite>();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k);
        }

        [TestMethod]
        public void ActionWith3RefArguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithContinueFlowBehaviour_OmitsTheOnSuccessAdvice() {
            var instance = container.Resolve<IActionWith3RefArgumentsComposite>();
            var joinPoints = new WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints().Calculate();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref i, ref j, ref k);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
        }

        [TestMethod]
        public void ActionWith3RefArguments_AnnotatedWithATryFinallyOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocation_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith3RefArgumentsComposite>();
            var joinPoints = new TryFinallyWithExceptionOnMethodBoundaryAspectOrderedJoinPoints().Calculate();

            try {
                instance.TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k);
            }
            catch (Exception) {
                Assert.AreEqual(i, joinPoints);
                Assert.AreEqual(j, joinPoints);
                Assert.AreEqual(k, joinPoints);
            }
        }

        [TestMethod]
        public void ActionWith3RefArguments_OnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithoutTryFinally_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith3RefArgumentsComposite>();
            var joinPoints = new OnMethodBoundaryAspectWithExceptionAndWithoutTryFinallyOrderedJoinPoints().Calculate();

            try {
                instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref i, ref j, ref k);
            }
            catch (Exception) {
                Assert.AreEqual(i, joinPoints);
                Assert.AreEqual(j, joinPoints);
                Assert.AreEqual(k, joinPoints);
            }
        }

        [TestMethod]
        public void ActionWith3RefArguments_OnMethodBoundaryAspectWithOnlyOnEntryAdvice_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith3RefArgumentsComposite>();
            var joinPoints = new OnMethodBoundaryAspectWithOnlyOnEntryAdviceOrderedJoinPoints().Calculate();
            
            instance.OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref i, ref j, ref k);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
        }
    }
}