using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.FunctionWith1ArgumentAspect.Subjects;
using NCop.Composite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class FunctionWith1ArgumentAspectTest : AbstractAspectTest
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
        public void FunctionWith1Argument_AnnotatedWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith1ArgumentComposite>();
            var list = new List<AspectJoinPoints>();
            var joinPoints = new OnMethodBoundaryAspectOrderedJoinPoints();
            var result = instance.OnMethodBoundaryAspect(list);

            CollectionAssert.AreEqual(list, joinPoints);
            CollectionAssert.DoesNotContain(list, AspectJoinPoints.OnException);
            Assert.AreEqual(result, joinPoints.ToString());
        }

        [TestMethod]
        public void FunctionWith1Argument_AnnotatedWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith1ArgumentComposite>();
            var list = new List<AspectJoinPoints>();
            var joinPoints = new InterceptionAspectOrderedJoinPoints();
            var result = instance.InterceptionAspect(list);

            CollectionAssert.AreEqual(list, joinPoints);
            Assert.AreEqual(result, joinPoints.ToString());
        }

        [TestMethod]
        public void FunctionWith1Argument_AnnotatedWithMultipleInterceptionAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith1ArgumentComposite>();
            var list = new List<AspectJoinPoints>();
            var joinPoints = new MultipleInterceptionAspectOrderedJoinPoints();
            var result  = instance.MultipleInterceptionAspects(list);

            CollectionAssert.AreEqual(list, joinPoints);
            Assert.AreEqual(result, joinPoints.ToString());
        }

        [TestMethod]
        public void FunctionWith1Argument_AnnotatedWithMultipleOnMethodBoundaryAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith1ArgumentComposite>();
            var list = new List<AspectJoinPoints>();
            var joinPoints = new MultipleOnMethodBoundaryAspectOrderedJoinPoints();
            var result = instance.MultipleOnMethodBoundaryAspects(list);

            CollectionAssert.AreEqual(list, joinPoints);
            CollectionAssert.DoesNotContain(list, AspectJoinPoints.OnException);
            Assert.AreEqual(result, joinPoints.ToString());
        }

        [TestMethod]
        public void FunctionWith1Argument_AnnotatedWithAllAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith1ArgumentComposite>();
            var list = new List<AspectJoinPoints>();
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithInterceptionAspect();
            var result = instance.AllAspectsStartingWithInterception(list);

            CollectionAssert.AreEqual(list, joinPoints);
            Assert.AreEqual(result, joinPoints.ToString());
        }

        [TestMethod]
        public void FunctionWith1Argument_AnnotatedWithAllAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith1ArgumentComposite>();
            var list = new List<AspectJoinPoints>();
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect();
            var result = instance.AllAspectsStartingWithOnMethodBoundary(list);

            CollectionAssert.AreEqual(list, joinPoints);
            CollectionAssert.DoesNotContain(list, AspectJoinPoints.OnException);
            Assert.AreEqual(result, joinPoints.ToString());
        }
        
        [TestMethod]
        public void FunctionWith1Argument_AnnotatedWithAlternateAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith1ArgumentComposite>();
            var list = new List<AspectJoinPoints>();
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithInterceptionAspect();
            var result = instance.AlternatelAspectsStartingWithInterception(list);

            CollectionAssert.AreEqual(list, joinPoints);
            Assert.AreEqual(result, joinPoints.ToString());
        }

        [TestMethod]
        public void FunctionWith1Argument_AnnotatedWithAlternateAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith1ArgumentComposite>();
            var list = new List<AspectJoinPoints>();
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect();
            var result = instance.AlternateAspectsStartingWithOnMethodBoundary(list);

            CollectionAssert.AreEqual(list, joinPoints);
            CollectionAssert.DoesNotContain(list, AspectJoinPoints.OnException);
            Assert.AreEqual(result, joinPoints.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FunctionWith1Argument_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithDefaultFlowBehaviour_ThrowsException() {
            var instance = container.Resolve<IFunctionWith1ArgumentComposite>();
            var list = new List<AspectJoinPoints>();
            var joinPoints = new InterceptionAspectOrderedJoinPoints();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(list);
        }

        [TestMethod]
        public void FunctionWith1Argument_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithContinueFlowBehaviour_OmitsTheOnSuccessAdvice() {
            var instance = container.Resolve<IFunctionWith1ArgumentComposite>();
            var list = new List<AspectJoinPoints>();
            var joinPoints = new WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints();
            var result = instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(list);

            CollectionAssert.AreEqual(list, joinPoints);
            Assert.AreEqual(result, joinPoints.ToString());
        }
    }
}