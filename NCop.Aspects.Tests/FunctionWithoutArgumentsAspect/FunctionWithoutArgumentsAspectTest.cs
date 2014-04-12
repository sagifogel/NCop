using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.FunctionWithoutArgumentAspect.Subjects;
using NCop.Composite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class FunctionWithoutArgumentAspectTest : AbstractAspectTest
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

        [TestInitialize()]
        public void CleanJoinPointsContainerForEachTest() {
            JoinPointsContainer.JoinPoints.Clear();
        }

        [TestMethod]
        public void FunctionWithoutArguments_AnnotatedWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWithoutArgumentsComposite>();
            var result = instance.OnMethodBoundaryAspect();

            CollectionAssert.AreEqual(JoinPointsContainer.JoinPoints, new OnMethodBoundaryAspectOrderedJoinPoints());
            CollectionAssert.DoesNotContain(JoinPointsContainer.JoinPoints, AspectJoinPoints.OnException);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(JoinPointsContainer.JoinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWithoutArguments_AnnotatedWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWithoutArgumentsComposite>();
            var result = instance.InterceptionAspect();
            
            CollectionAssert.AreEqual(JoinPointsContainer.JoinPoints, new InterceptionAspectOrderedJoinPoints());
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(JoinPointsContainer.JoinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWithoutArguments_AnnotatedWithMultipleInterceptionAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWithoutArgumentsComposite>();
            var result = instance.MultipleInterceptionAspects();

            CollectionAssert.AreEqual(JoinPointsContainer.JoinPoints, new MultipleInterceptionAspectOrderedJoinPoints());
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(JoinPointsContainer.JoinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWithoutArguments_AnnotatedWithMultipleOnMethodBoundaryAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWithoutArgumentsComposite>();
            var result = instance.MultipleOnMethodBoundaryAspects();

            CollectionAssert.AreEqual(JoinPointsContainer.JoinPoints, new MultipleOnMethodBoundaryAspectOrderedJoinPoints());
            CollectionAssert.DoesNotContain(JoinPointsContainer.JoinPoints, AspectJoinPoints.OnException);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(JoinPointsContainer.JoinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWithoutArguments_AnnotatedWithAllAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWithoutArgumentsComposite>();
            var result = instance.AllAspectsStartingWithInterception();
            
            CollectionAssert.AreEqual(JoinPointsContainer.JoinPoints, new AllAspectOrderedJoinPointsStartingWithInterceptionAspect());
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(JoinPointsContainer.JoinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWithoutArguments_AnnotatedWithAllAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWithoutArgumentsComposite>();
            var result = instance.AllAspectsStartingWithOnMethodBoundary();

            CollectionAssert.AreEqual(JoinPointsContainer.JoinPoints, new AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect());
            CollectionAssert.DoesNotContain(JoinPointsContainer.JoinPoints, AspectJoinPoints.OnException);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(JoinPointsContainer.JoinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWithoutArguments_AnnotatedWithAlternateAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWithoutArgumentsComposite>();
            var result = instance.AlternatelAspectsStartingWithInterception();
            
            CollectionAssert.AreEqual(JoinPointsContainer.JoinPoints, new AlternateAspectOrderedJoinPointsStartingWithInterceptionAspect());
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(JoinPointsContainer.JoinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWithoutArguments_AnnotatedWithAlternateAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWithoutArgumentsComposite>();
            var result = instance.AlternateAspectsStartingWithOnMethodBoundary();

            CollectionAssert.AreEqual(JoinPointsContainer.JoinPoints, new AlternateAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect());
            CollectionAssert.DoesNotContain(JoinPointsContainer.JoinPoints, AspectJoinPoints.OnException);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(JoinPointsContainer.JoinPoints).ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FunctionWithoutArguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithDefaultFlowBehaviour_ThrowsException() {
            var instance = container.Resolve<IFunctionWithoutArgumentsComposite>();
            
            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl();
        }

        [TestMethod]
        public void FunctionWithoutArguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithContinueFlowBehaviour_OmitsTheOnSuccessAdvice() {
            var instance = container.Resolve<IFunctionWithoutArgumentsComposite>();
            var result = instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect();

            CollectionAssert.AreEqual(JoinPointsContainer.JoinPoints, new WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints());
            Assert.AreEqual(result, JoinPointsContainer.JoinPoints.ToString());
        }
    }
}