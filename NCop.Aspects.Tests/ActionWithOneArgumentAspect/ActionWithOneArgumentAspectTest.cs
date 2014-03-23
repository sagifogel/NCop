using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.ActionWithOneArgumentAspect.Subjects;
using NCop.Composite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class ActionWithOneArgumentAspectTest : AbstractAspectTest
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
        public void ActionWithOneArgumentMethod_AnnotatedWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWithOneArgumentComposite>();
            var list = new List<AspectJoinPoints>();

            instance.OnMethodBoundaryAspect(list);

            CollectionAssert.AreEqual(list, new OnMethodBoundaryAspectOrderedJoinPoints());
            CollectionAssert.DoesNotContain(list, AspectJoinPoints.OnException);
        }

        [TestMethod]
        public void ActionWithOneArgumentMethod_AnnotatedWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IActionWithOneArgumentComposite>();
            var list = new List<AspectJoinPoints>();

            instance.InterceptionAspect(list);
            CollectionAssert.AreEqual(list, new InterceptionAspectOrderedJoinPoints());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ActionWithOneArgumentMethod_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithDefaultFlowBehaviour_ThrowsException() {
            var instance = container.Resolve<IActionWithOneArgumentComposite>();
            var list = new List<AspectJoinPoints>();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(list);
        }

        [TestMethod]
        public void ActionWithOneArgumentMethod_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithContinueFlowBehaviour_OmitTheOnSuccessAdvice() {
            var instance = container.Resolve<IActionWithOneArgumentComposite>();
            var list = new List<AspectJoinPoints>();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehavipurAspect(list);
            CollectionAssert.AreEqual(list, new WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints());
        }
    }
}