using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.ActionWithoutArgumentAspect.Subjects;
using System;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class ActionWithoutArgumentAspectTest : AbstractAspectTest
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
        public void ActionWithoutArguments_AnnotatedWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWithoutArgumentsComposite>();

            instance.OnMethodBoundaryAspect();

            CollectionAssert.AreEqual(JoinPointsContainer.JoinPoints, new OnMethodBoundaryAspectOrderedJoinPoints());
            CollectionAssert.DoesNotContain(JoinPointsContainer.JoinPoints, AspectJoinPoints.OnException);
        }

        [TestMethod]
        public void ActionWithoutArguments_AnnotatedWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWithoutArgumentsComposite>();

            instance.InterceptionAspect();
            CollectionAssert.AreEqual(JoinPointsContainer.JoinPoints, new InterceptionAspectOrderedJoinPoints());
        }

        [TestMethod]
        public void ActionWithoutArguments_AnnotatedWithMultipleInterceptionAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWithoutArgumentsComposite>();

            instance.MultipleInterceptionAspects();
            CollectionAssert.AreEqual(JoinPointsContainer.JoinPoints, new MultipleInterceptionAspectOrderedJoinPoints());
        }

        [TestMethod]
        public void ActionWithoutArguments_AnnotatedWithMultipleOnMethodBoundaryAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWithoutArgumentsComposite>();

            instance.MultipleOnMethodBoundaryAspects();

            CollectionAssert.AreEqual(JoinPointsContainer.JoinPoints, new MultipleOnMethodBoundaryAspectOrderedJoinPoints());
            CollectionAssert.DoesNotContain(JoinPointsContainer.JoinPoints, AspectJoinPoints.OnException);
        }

        [TestMethod]
        public void ActionWithoutArguments_AnnotatedWithAllAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWithoutArgumentsComposite>();

            instance.AllAspectsStartingWithInterception();
            CollectionAssert.AreEqual(JoinPointsContainer.JoinPoints, new AllAspectOrderedJoinPointsStartingWithInterceptionAspect());
        }

        [TestMethod]
        public void ActionWithoutArguments_AnnotatedWithAllAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWithoutArgumentsComposite>();

            instance.AllAspectsStartingWithOnMethodBoundary();

            CollectionAssert.AreEqual(JoinPointsContainer.JoinPoints, new AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect());
            CollectionAssert.DoesNotContain(JoinPointsContainer.JoinPoints, AspectJoinPoints.OnException);
        }

        [TestMethod]
        public void ActionWithoutArguments_AnnotatedWithAlternateAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWithoutArgumentsComposite>();

            instance.AlternatelAspectsStartingWithInterception();
            CollectionAssert.AreEqual(JoinPointsContainer.JoinPoints, new AlternateAspectOrderedJoinPointsStartingWithInterceptionAspect());
        }

        [TestMethod]
        public void ActionWithoutArguments_AnnotatedWithAlternateAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWithoutArgumentsComposite>();

            instance.AlternateAspectsStartingWithOnMethodBoundary();

            CollectionAssert.AreEqual(JoinPointsContainer.JoinPoints, new AlternateAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect());
            CollectionAssert.DoesNotContain(JoinPointsContainer.JoinPoints, AspectJoinPoints.OnException);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ActionWithoutArguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithDefaultFlowBehaviour_ThrowsException() {
            var instance = container.Resolve<IActionWithoutArgumentsComposite>();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl();
        }

        [TestMethod]
        public void ActionWithoutArguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithContinueFlowBehaviour_OmitsTheOnSuccessAdvice() {
            var instance = container.Resolve<IActionWithoutArgumentsComposite>();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect();
            CollectionAssert.AreEqual(JoinPointsContainer.JoinPoints, new WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints());
        }
    }
}