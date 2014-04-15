using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.FunctionWith6RefArgumentsAspect.Subjects;
using NCop.Composite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class FunctionWith6RefArgumentsAspectTest : AbstractAspectTest
    {
        private int i = 0;
        private int j = 0;
        private int k = 0;
        private int l = 0;
        private int m = 0;
        private int n = 0;
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
            n = m = l = k = j = i = 0;
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.OnMethodBoundaryAspect(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new OnMethodBoundaryAspectOrderedJoinPoints();

            Assert.AreEqual(i, joinPoints.Calculate());
            Assert.AreEqual(j, joinPoints.Calculate());
            Assert.AreEqual(k, joinPoints.Calculate());
            Assert.AreEqual(l, joinPoints.Calculate());
            Assert.AreEqual(m, joinPoints.Calculate());
            Assert.AreEqual(n, joinPoints.Calculate());
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.InterceptionAspect(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new InterceptionAspectOrderedJoinPoints();

            Assert.AreEqual(i, joinPoints.Calculate());
            Assert.AreEqual(j, joinPoints.Calculate());
            Assert.AreEqual(k, joinPoints.Calculate());
            Assert.AreEqual(l, joinPoints.Calculate());
            Assert.AreEqual(m, joinPoints.Calculate());
            Assert.AreEqual(n, joinPoints.Calculate());
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithMultipleInterceptionAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.MultipleInterceptionAspects(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new MultipleInterceptionAspectOrderedJoinPoints();

            Assert.AreEqual(i, joinPoints.Calculate());
            Assert.AreEqual(j, joinPoints.Calculate());
            Assert.AreEqual(k, joinPoints.Calculate());
            Assert.AreEqual(l, joinPoints.Calculate());
            Assert.AreEqual(m, joinPoints.Calculate());
            Assert.AreEqual(n, joinPoints.Calculate());
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithMultipleOnMethodBoundaryAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.MultipleOnMethodBoundaryAspects(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new MultipleOnMethodBoundaryAspectOrderedJoinPoints();

            Assert.AreEqual(i, joinPoints.Calculate());
            Assert.AreEqual(j, joinPoints.Calculate());
            Assert.AreEqual(k, joinPoints.Calculate());
            Assert.AreEqual(l, joinPoints.Calculate());
            Assert.AreEqual(m, joinPoints.Calculate());
            Assert.AreEqual(n, joinPoints.Calculate());
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithAllAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.AllAspectsStartingWithInterception(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithInterceptionAspect();

            Assert.AreEqual(i, joinPoints.Calculate());
            Assert.AreEqual(j, joinPoints.Calculate());
            Assert.AreEqual(k, joinPoints.Calculate());
            Assert.AreEqual(l, joinPoints.Calculate());
            Assert.AreEqual(m, joinPoints.Calculate());
            Assert.AreEqual(n, joinPoints.Calculate());
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithAllAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.AllAspectsStartingWithOnMethodBoundary(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect();

            Assert.AreEqual(i, joinPoints.Calculate());
            Assert.AreEqual(j, joinPoints.Calculate());
            Assert.AreEqual(k, joinPoints.Calculate());
            Assert.AreEqual(l, joinPoints.Calculate());
            Assert.AreEqual(m, joinPoints.Calculate());
            Assert.AreEqual(n, joinPoints.Calculate());
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithAlternateAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.AlternatelAspectsStartingWithInterception(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithInterceptionAspect();

            Assert.AreEqual(i, joinPoints.Calculate());
            Assert.AreEqual(j, joinPoints.Calculate());
            Assert.AreEqual(k, joinPoints.Calculate());
            Assert.AreEqual(l, joinPoints.Calculate());
            Assert.AreEqual(m, joinPoints.Calculate());
            Assert.AreEqual(n, joinPoints.Calculate());
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithAlternateAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.AlternateAspectsStartingWithOnMethodBoundary(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect();

            Assert.AreEqual(i, joinPoints.Calculate());
            Assert.AreEqual(j, joinPoints.Calculate());
            Assert.AreEqual(k, joinPoints.Calculate());
            Assert.AreEqual(l, joinPoints.Calculate());
            Assert.AreEqual(m, joinPoints.Calculate());
            Assert.AreEqual(n, joinPoints.Calculate());
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FunctionWith6RefArguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithDefaultFlowBehaviour_ThrowsException() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithContinueFlowBehaviour_OmitsTheOnSuccessAdvice() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints();

            Assert.AreEqual(i, joinPoints.Calculate());
            Assert.AreEqual(j, joinPoints.Calculate());
            Assert.AreEqual(k, joinPoints.Calculate());
            Assert.AreEqual(l, joinPoints.Calculate());
            Assert.AreEqual(m, joinPoints.Calculate());
            Assert.AreEqual(n, joinPoints.Calculate());
            Assert.AreEqual(result, joinPoints.ToString());
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithATryFinallyOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocation_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            string result = null;
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var joinPoints = new TryFinallyWithExceptionOnMethodBoundaryAspectOrderedJoinPoints();

            try {
                result = instance.TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n);
            }
            catch (Exception) {
                Assert.AreEqual(i, joinPoints.Calculate());
                Assert.AreEqual(j, joinPoints.Calculate());
                Assert.AreEqual(k, joinPoints.Calculate());
                Assert.AreEqual(l, joinPoints.Calculate());
                Assert.AreEqual(m, joinPoints.Calculate());
                Assert.AreEqual(n, joinPoints.Calculate());
                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public void FunctionWith6RefArguments_OnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithoutTryFinally_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            string result = null;
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var joinPoints = new OnMethodBoundaryAspectWithExceptionAndWithoutTryFinallyOrderedJoinPoints();

            try {
                result = instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref i, ref j, ref k, ref l, ref m, ref n);
            }
            catch (Exception) {
                Assert.AreEqual(i, joinPoints.Calculate());
                Assert.AreEqual(j, joinPoints.Calculate());
                Assert.AreEqual(k, joinPoints.Calculate());
                Assert.AreEqual(l, joinPoints.Calculate());
                Assert.AreEqual(m, joinPoints.Calculate());
                Assert.AreEqual(n, joinPoints.Calculate());
                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public void FunctionWith6RefArguments_OnMethodBoundaryAspectWithOnlyOnEntryAdvice_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new OnMethodBoundaryAspectWithOnlyOnEntryAdviceOrderedJoinPoints();

            Assert.AreEqual(i, joinPoints.Calculate());
            Assert.AreEqual(j, joinPoints.Calculate());
            Assert.AreEqual(k, joinPoints.Calculate());
            Assert.AreEqual(l, joinPoints.Calculate());
            Assert.AreEqual(m, joinPoints.Calculate());
            Assert.AreEqual(n, joinPoints.Calculate());
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }
    }
}