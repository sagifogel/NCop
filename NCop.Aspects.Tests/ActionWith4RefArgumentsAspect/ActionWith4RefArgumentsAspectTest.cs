using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.ActionWith4RefArgumentsAspect.Subjects;
using NCop.Composite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class ActionWith4RefArgumentsAspectTest : AbstractAspectTest
    {
        private int i = 0;
        private int j = 0;
        private int k = 0;
        private int l = 0;
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
            l = i = j = k = 0;
        }

        [TestMethod]
        public void ActionWith4RefArguments_AnnotatedWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith4RefArgumentsComposite>();
            var joinPoints = new OnMethodBoundaryAspectOrderedJoinPoints().Calculate();

            instance.OnMethodBoundaryAspect(ref i, ref j, ref k, ref l);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
            Assert.AreEqual(l, joinPoints);
            Assert.AreEqual(l, joinPoints);
        }

        [TestMethod]
        public void ActionWith4RefArguments_AnnotatedWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith4RefArgumentsComposite>();
            var joinPoints = new InterceptionAspectOrderedJoinPoints().Calculate();

            instance.InterceptionAspect(ref i, ref j, ref k, ref l);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
            Assert.AreEqual(l, joinPoints);
        }

        [TestMethod]
        public void ActionWith4RefArguments_AnnotatedWithMultipleInterceptionAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith4RefArgumentsComposite>();
            var joinPoints = new MultipleInterceptionAspectOrderedJoinPoints().Calculate();

            instance.MultipleInterceptionAspects(ref i, ref j, ref k, ref l);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
            Assert.AreEqual(l, joinPoints);
        }

        [TestMethod]
        public void ActionWith4RefArguments_AnnotatedWithMultipleOnMethodBoundaryAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith4RefArgumentsComposite>();
            var joinPoints = new MultipleOnMethodBoundaryAspectOrderedJoinPoints().Calculate();

            instance.MultipleOnMethodBoundaryAspects(ref i, ref j, ref k, ref l);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
            Assert.AreEqual(l, joinPoints);
        }

        [TestMethod]
        public void ActionWith4RefArguments_AnnotatedWithAllAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith4RefArgumentsComposite>();
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithInterceptionAspect().Calculate();

            instance.AllAspectsStartingWithInterception(ref i, ref j, ref k, ref l);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
            Assert.AreEqual(l, joinPoints);
        }

        [TestMethod]
        public void ActionWith4RefArguments_AnnotatedWithAllAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith4RefArgumentsComposite>();
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect().Calculate();

            instance.AllAspectsStartingWithOnMethodBoundary(ref i, ref j, ref k, ref l);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
            Assert.AreEqual(l, joinPoints);
        }

        [TestMethod]
        public void ActionWith4RefArguments_AnnotatedWithAlternateAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith4RefArgumentsComposite>();
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithInterceptionAspect().Calculate();

            instance.AlternatelAspectsStartingWithInterception(ref i, ref j, ref k, ref l);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
            Assert.AreEqual(l, joinPoints);
        }

        [TestMethod]
        public void ActionWith4RefArguments_AnnotatedWithAlternateAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith4RefArgumentsComposite>();
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect().Calculate();

            instance.AlternateAspectsStartingWithOnMethodBoundary(ref i, ref j, ref k, ref l);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
            Assert.AreEqual(l, joinPoints);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ActionWith4RefArguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithDefaultFlowBehaviour_ThrowsException() {
            var instance = container.Resolve<IActionWith4RefArgumentsComposite>();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l);
        }

        [TestMethod]
        public void ActionWith4RefArguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithContinueFlowBehaviour_OmitsTheOnSuccessAdvice() {
            var instance = container.Resolve<IActionWith4RefArgumentsComposite>();
            var joinPoints = new WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints().Calculate();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref i, ref j, ref k, ref l);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
            Assert.AreEqual(l, joinPoints);
        }

        [TestMethod]
        public void ActionWith4RefArguments_AnnotatedWithATryFinallyOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocation_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith4RefArgumentsComposite>();
            var joinPoints = new TryFinallyWithExceptionOnMethodBoundaryAspectOrderedJoinPoints().Calculate();

            try {
                instance.TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l);
            }
            catch (Exception) {
                Assert.AreEqual(i, joinPoints);
                Assert.AreEqual(j, joinPoints);
                Assert.AreEqual(k, joinPoints);
                Assert.AreEqual(l, joinPoints);
            }
        }

        [TestMethod]
        public void ActionWith4RefArguments_OnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithoutTryFinally_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith4RefArgumentsComposite>();
            var joinPoints = new OnMethodBoundaryAspectWithExceptionAndWithoutTryFinallyOrderedJoinPoints().Calculate();

            try {
                instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref i, ref j, ref k, ref l);
            }
            catch (Exception) {
                Assert.AreEqual(i, joinPoints);
                Assert.AreEqual(j, joinPoints);
                Assert.AreEqual(k, joinPoints);
                Assert.AreEqual(l, joinPoints);
            }
        }

        [TestMethod]
        public void ActionWith4RefArguments_OnMethodBoundaryAspectWithOnlyOnEntryAdvice_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith4RefArgumentsComposite>();
            var joinPoints = new OnMethodBoundaryAspectWithOnlyOnEntryAdviceOrderedJoinPoints().Calculate();
            
            instance.OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref i, ref j, ref k, ref l);

            Assert.AreEqual(i, joinPoints);
            Assert.AreEqual(j, joinPoints);
            Assert.AreEqual(k, joinPoints);
            Assert.AreEqual(l, joinPoints);
        }
    }
}