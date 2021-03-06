﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.FunctionWith2RefArgumentsAspect.Subjects;
using System;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class FunctionWith2RefArgumentsAspectTest : AbstractAspectTest
    {
        private int i = 0;
        private int j = 0;
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
            j = i = 0;
        }

        [TestMethod]
        public void FunctionWith2RefArguments_AnnotatedWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith2RefArgumentsComposite>();
            var result = instance.OnMethodBoundaryAspect(ref i, ref j);
            var joinPoints = new OnMethodBoundaryAspectOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith2RefArguments_AnnotatedWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith2RefArgumentsComposite>();
            var result = instance.InterceptionAspect(ref i, ref j);
            var joinPoints = new InterceptionAspectOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith2RefArguments_AnnotatedWithMultipleInterceptionAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith2RefArgumentsComposite>();
            var result = instance.MultipleInterceptionAspects(ref i, ref j);
            var joinPoints = new MultipleInterceptionAspectOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith2RefArguments_AnnotatedWithMultipleOnMethodBoundaryAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith2RefArgumentsComposite>();
            var result = instance.MultipleOnMethodBoundaryAspects(ref i, ref j);
            var joinPoints = new MultipleOnMethodBoundaryAspectOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith2RefArguments_AnnotatedWithAllAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith2RefArgumentsComposite>();
            var result = instance.AllAspectsStartingWithInterception(ref i, ref j);
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithInterceptionAspect();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith2RefArguments_AnnotatedWithAllAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith2RefArgumentsComposite>();
            var result = instance.AllAspectsStartingWithOnMethodBoundary(ref i, ref j);
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith2RefArguments_AnnotatedWithAlternateAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith2RefArgumentsComposite>();
            var result = instance.AlternatelAspectsStartingWithInterception(ref i, ref j);
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithInterceptionAspect();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith2RefArguments_AnnotatedWithAlternateAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith2RefArgumentsComposite>();
            var result = instance.AlternateAspectsStartingWithOnMethodBoundary(ref i, ref j);
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FunctionWith2RefArguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithDefaultFlowBehaviour_ThrowsException() {
            var instance = container.Resolve<IFunctionWith2RefArgumentsComposite>();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j);
        }

        [TestMethod]
        public void FunctionWith2RefArguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithContinueFlowBehaviour_OmitsTheOnSuccessAdvice() {
            var instance = container.Resolve<IFunctionWith2RefArgumentsComposite>();
            var result = instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref i, ref j);
            var joinPoints = new WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(result, joinPoints.ToString());
        }

        [TestMethod]
        public void FunctionWith2RefArguments_AnnotatedWithATryFinallyOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocation_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            string result = null;
            var instance = container.Resolve<IFunctionWith2RefArgumentsComposite>();
            var joinPoints = new TryFinallyWithExceptionOnMethodBoundaryAspectOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            try {
                result = instance.TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j);
            }
            catch (Exception) {
                Assert.AreEqual(i, calculated);
                Assert.AreEqual(j, calculated);
                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public void FunctionWith2RefArguments_OnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithoutTryFinally_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            string result = null;
            var instance = container.Resolve<IFunctionWith2RefArgumentsComposite>();
            var joinPoints = new OnMethodBoundaryAspectWithExceptionAndWithoutTryFinallyOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            try {
                result = instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref i, ref j);
            }
            catch (Exception) {
                Assert.AreEqual(i, calculated);
                Assert.AreEqual(j, calculated);
                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public void FunctionWith2RefArguments_OnMethodBoundaryAspectWithOnlyOnEntryAdvice_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith2RefArgumentsComposite>();
            var result = instance.OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref i, ref j);
            var joinPoints = new OnMethodBoundaryAspectWithOnlyOnEntryAdviceOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith2RefArguments_AnnotatedWithAllAspectsStartingFromInterceptionAspectThatCallsTheInvokeMethodOfTheArgs_ReturnsTheInMethodAdviceAndIgnoresAllOtherAspects() {
            var instance = container.Resolve<IFunctionWith2RefArgumentsComposite>();
            var result = instance.InterceptionAspectUsingInvoke(ref i, ref j);
            var joinPoints = new InterceptionAspectUsingInvokeOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }
    }
}