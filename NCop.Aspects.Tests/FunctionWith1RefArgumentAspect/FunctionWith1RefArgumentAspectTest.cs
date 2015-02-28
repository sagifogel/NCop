using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.FunctionWith1RefArgumentAspect.Subjects;
using System;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class FunctionWith1RefArgumentAspectTest : AbstractAspectTest
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
        public void FunctionWith1RefArgument_AnnotatedWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith1RefArgumentComposite>();
            var result = instance.OnMethodBoundaryAspect(ref i);
            var joinPoints = new OnMethodBoundaryAspectOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith1RefArgument_AnnotatedWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith1RefArgumentComposite>();
            var result = instance.InterceptionAspect(ref i);
            var joinPoints = new InterceptionAspectOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith1RefArgument_AnnotatedWithMultipleInterceptionAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith1RefArgumentComposite>();
            var result = instance.MultipleInterceptionAspects(ref i);
            var joinPoints = new MultipleInterceptionAspectOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith1RefArgument_AnnotatedWithMultipleOnMethodBoundaryAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith1RefArgumentComposite>();
            var result = instance.MultipleOnMethodBoundaryAspects(ref i);
            var joinPoints = new MultipleOnMethodBoundaryAspectOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith1RefArgument_AnnotatedWithAllAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith1RefArgumentComposite>();
            var result = instance.AllAspectsStartingWithInterception(ref i);
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithInterceptionAspect();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith1RefArgument_AnnotatedWithAllAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith1RefArgumentComposite>();
            var result = instance.AllAspectsStartingWithOnMethodBoundary(ref i);
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith1RefArgument_AnnotatedWithAlternateAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith1RefArgumentComposite>();
            var result = instance.AlternatelAspectsStartingWithInterception(ref i);
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithInterceptionAspect();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith1RefArgument_AnnotatedWithAlternateAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith1RefArgumentComposite>();
            var result = instance.AlternateAspectsStartingWithOnMethodBoundary(ref i);
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FunctionWith1RefArgument_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithDefaultFlowBehaviour_ThrowsException() {
            var instance = container.Resolve<IFunctionWith1RefArgumentComposite>();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i);
        }

        [TestMethod]
        public void FunctionWith1RefArgument_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithContinueFlowBehaviour_OmitsTheOnSuccessAdvice() {
            var instance = container.Resolve<IFunctionWith1RefArgumentComposite>();
            var result = instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref i);
            var joinPoints = new WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(result, joinPoints.ToString());
        }

        [TestMethod]
        public void FunctionWith1RefArgument_AnnotatedWithATryFinallyOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocation_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            string result = null;
            var instance = container.Resolve<IFunctionWith1RefArgumentComposite>();
            var joinPoints = new TryFinallyWithExceptionOnMethodBoundaryAspectOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            try {
                result = instance.TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i);
            }
            catch (Exception) {
                Assert.AreEqual(i, calculated);
                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public void FunctionWith1RefArgument_OnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithoutTryFinally_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            string result = null;
            var instance = container.Resolve<IFunctionWith1RefArgumentComposite>();
            var joinPoints = new OnMethodBoundaryAspectWithExceptionAndWithoutTryFinallyOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            try {
                result = instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref i);
            }
            catch (Exception) {
                Assert.AreEqual(i, calculated);
                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public void FunctionWith1RefArgument_OnMethodBoundaryAspectWithOnlyOnEntryAdvice_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith1RefArgumentComposite>();
            var result = instance.OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref i);
            var joinPoints = new OnMethodBoundaryAspectWithOnlyOnEntryAdviceOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith1RefArgument_AnnotatedWithAllAspectsStartingFromInterceptionAspectThatCallsTheInvokeMethodOfTheArgs_ReturnsTheInMethodAdviceAndIgnoresAllOtherAspects() {
            var instance = container.Resolve<IFunctionWith1RefArgumentComposite>();
            var result = instance.InterceptionAspectUsingInvoke(ref i);
            var joinPoints = new InterceptionAspectUsingInvokeOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }
    }
}