using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.ActionWith8ArgumentsAspect.Subjects;
using NCop.Composite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class ActionWith8ArgumentsAspectTest : AbstractAspectTest
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
        public void ActionWith8Arguments_AnnotatedWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eights = new List<AspectJoinPoints>();
            var joinPoints = new OnMethodBoundaryAspectOrderedJoinPoints();

            instance.OnMethodBoundaryAspect(first, second, third, fourth, fifth, sixth, seventh, eights);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.DoesNotContain(first, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(second, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(third, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(fourth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(fifth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(sixth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(seventh, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(eights, AspectJoinPoints.OnException);
        }

        [TestMethod]
        public void ActionWith8Arguments_AnnotatedWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eights = new List<AspectJoinPoints>();
            var joinPoints = new InterceptionAspectOrderedJoinPoints();

            instance.InterceptionAspect(first, second, third, fourth, fifth, sixth, seventh, eights);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eights, joinPoints);
        }

        [TestMethod]
        public void ActionWith8Arguments_AnnotatedWithMultipleInterceptionAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eights = new List<AspectJoinPoints>();
            var joinPoints = new MultipleInterceptionAspectOrderedJoinPoints();

            instance.MultipleInterceptionAspects(first, second, third, fourth, fifth, sixth, seventh, eights);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eights, joinPoints);
        }

        [TestMethod]
        public void ActionWith8Arguments_AnnotatedWithMultipleOnMethodBoundaryAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eights = new List<AspectJoinPoints>();
            var joinPoints = new MultipleOnMethodBoundaryAspectOrderedJoinPoints();

            instance.MultipleOnMethodBoundaryAspects(first, second, third, fourth, fifth, sixth, seventh, eights);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eights, joinPoints);
            CollectionAssert.DoesNotContain(first, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(second, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(third, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(fourth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(fifth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(sixth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(seventh, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(eights, AspectJoinPoints.OnException);
        }

        [TestMethod]
        public void ActionWith8Arguments_AnnotatedWithAllAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eights = new List<AspectJoinPoints>();
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithInterceptionAspect();

            instance.AllAspectsStartingWithInterception(first, second, third, fourth, fifth, sixth, seventh, eights);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eights, joinPoints);
        }

        [TestMethod]
        public void ActionWith8Arguments_AnnotatedWithAllAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eights = new List<AspectJoinPoints>();
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect();

            instance.AllAspectsStartingWithOnMethodBoundary(first, second, third, fourth, fifth, sixth, seventh, eights);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eights, joinPoints);
            CollectionAssert.DoesNotContain(first, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(second, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(third, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(fourth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(fifth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(sixth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(seventh, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(eights, AspectJoinPoints.OnException);
        }

        [TestMethod]
        public void ActionWith8Arguments_AnnotatedWithAlternateAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eights = new List<AspectJoinPoints>();
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithInterceptionAspect();

            instance.AlternatelAspectsStartingWithInterception(first, second, third, fourth, fifth, sixth, seventh, eights);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eights, joinPoints);
        }

        [TestMethod]
        public void ActionWith8Arguments_AnnotatedWithAlternateAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eights = new List<AspectJoinPoints>();
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect();

            instance.AlternateAspectsStartingWithOnMethodBoundary(first, second, third, fourth, fifth, sixth, seventh, eights);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eights, joinPoints);
            CollectionAssert.DoesNotContain(first, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(second, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(third, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(fourth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(fifth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(sixth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(seventh, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(eights, AspectJoinPoints.OnException);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ActionWith8Arguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithDefaultFlowBehaviour_ThrowsException() {
            var instance = container.Resolve<IActionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eights = new List<AspectJoinPoints>();
            var joinPoints = new MultipleOnMethodBoundaryAspectOrderedJoinPoints();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth, fifth, sixth, seventh, eights);
        }

        [TestMethod]
        public void ActionWith8Arguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithContinueFlowBehaviour_OmitsTheOnSuccessAdvice() {
            var instance = container.Resolve<IActionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eights = new List<AspectJoinPoints>();
            var joinPoints = new WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(first, second, third, fourth, fifth, sixth, seventh, eights);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eights, joinPoints);
        }

        [TestMethod]
        public void ActionWith8Arguments_AnnotatedWithATryFinallyOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocation_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eights = new List<AspectJoinPoints>();
            var joinPoints = new TryFinallyWithExceptionOnMethodBoundaryAspectOrderedJoinPoints();

            try {
                instance.TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth, fifth, sixth, seventh, eights);
            }
            catch (Exception) {
                CollectionAssert.AreEqual(first, joinPoints);
                CollectionAssert.AreEqual(second, joinPoints);
                CollectionAssert.AreEqual(third, joinPoints);
                CollectionAssert.AreEqual(fourth, joinPoints);
                CollectionAssert.AreEqual(fifth, joinPoints);
                CollectionAssert.AreEqual(sixth, joinPoints);
                CollectionAssert.AreEqual(seventh, joinPoints);
                CollectionAssert.AreEqual(eights, joinPoints);
            }
        }

        [TestMethod]
        public void ActionWith8Arguments_OnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithoutTryFinally_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eights = new List<AspectJoinPoints>();
            var joinPoints = new OnMethodBoundaryAspectWithExceptionAndWithoutTryFinallyOrderedJoinPoints();

            try {
                instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(first, second, third, fourth, fifth, sixth, seventh, eights);
            }
            catch (Exception) {
                CollectionAssert.AreEqual(first, joinPoints);
                CollectionAssert.AreEqual(second, joinPoints);
                CollectionAssert.AreEqual(third, joinPoints);
                CollectionAssert.AreEqual(fourth, joinPoints);
                CollectionAssert.AreEqual(fifth, joinPoints);
                CollectionAssert.AreEqual(sixth, joinPoints);
                CollectionAssert.AreEqual(seventh, joinPoints);
                CollectionAssert.AreEqual(eights, joinPoints);
            }
        }

        [TestMethod]
        public void ActionWith8Arguments_OnMethodBoundaryAspectWithOnlyOnEntryAdvice_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eights = new List<AspectJoinPoints>();
            var joinPoints = new OnMethodBoundaryAspectWithOnlyOnEntryAdviceOrderedJoinPoints();

            instance.OnMethodBoundaryAspectWithOnlyOnEntryAdvide(first, second, third, fourth, fifth, sixth, seventh, eights);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eights, joinPoints);
        }
    }
}