using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.MethodsAndPropertiesAspect.Subjects;
using NCop.Aspects.Tests.PropertyAspect.Subjects;
using System.Collections.Generic;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class MethodsAndPropertiesAspectTest : AbstractAspectTest
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

        [TestInitialize]
        public void ResetPropertyInterceptionAspectsList() {
            PropertyInterceptionAspects.PropertyInterceptionAspectsList = new List<AspectJoinPoints>();
        }

        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void PropertyAndMethod_WithoutAnyAspectsAnnotations_ReturnsTheCorrectSequenceOfAdvices() {
            var list = new List<AspectJoinPoints>();
            var instance = container.Resolve<IMethodsAndPropertiesSubjectsComposite>();

            instance.VanillaMethodWithoutAnyAspects(list);
            instance.VanillaPropertyWithoutAnyAspects = list;
            list = instance.VanillaPropertyWithoutAnyAspects;

            CollectionAssert.AreEqual(list, new InterceptionAspectUsingInvokeOrderedJoinPoints());
        }

        [TestMethod]
        public void PropertyAndMethod_PropertyWithoutAnyAspectsAndMethodAnnotatedWithOnMethodBoundaryAspectAnnotations_ReturnsTheCorrectOnMethodBoundaryAspectSequenceOfAdvices() {
            var list = new List<AspectJoinPoints>();
            var instance = container.Resolve<IMethodsAndPropertiesSubjectsComposite>();

            instance.VanillaPropertyWithoutAnyAspects = list;
            instance.OnMethodBoundaryAspect(list);

            CollectionAssert.AreEqual(list, new OnMethodBoundaryAspectOrderedJoinPoints());
        }

        [TestMethod]
        public void PropertyAndMethod_PropertyWithoutAnyAspectsAndMethodAnnotatedWithInterceptionAspectAnnotations_ReturnsTheCorrectInterceptionAspectSequenceOfAdvices() {
            var list = new List<AspectJoinPoints>();
            var instance = container.Resolve<IMethodsAndPropertiesSubjectsComposite>();

            instance.VanillaPropertyWithoutAnyAspects = list;
            instance.InterceptionAspect(list);

            CollectionAssert.AreEqual(list, new InterceptionAspectOrderedJoinPoints());
        }

        [TestMethod]
        public void PropertyAndMethod_PropertyAnnotatedWithPropertyInterceptionAspectAndMethodWithoutAnyAspects_ReturnsTheCorrectInterceptionAspectSequenceOfAdvices() {
            var list = new List<AspectJoinPoints>();
            var instance = container.Resolve<IMethodsAndPropertiesSubjectsComposite>();
            var excpected = new PropertyInterceptionAspectOrderedJoinPoints();

            excpected.Add(AspectJoinPoints.InMethod);
            instance.PropertyInterceptionAspectOnFullProperty = list;
            list = instance.PropertyInterceptionAspectOnFullProperty;
            instance.VanillaMethodWithoutAnyAspects(list);

            CollectionAssert.AreEqual(list, excpected);
        }

        [TestMethod]
        public void PropertyAndMethod_PropertyAnnotatedWithPropertyInterceptionAspectAndMethodAnnotatedWithInterceptionAspectAnnotations_ReturnsTheCorrectInterceptionAspectSequenceOfAdvices() {
            var list = new List<AspectJoinPoints>();
            var instance = container.Resolve<IMethodsAndPropertiesSubjectsComposite>();
            var excpected = new PropertyInterceptionAspectOrderedJoinPoints();

            excpected.AddRange(new InterceptionAspectOrderedJoinPoints());
            instance.PropertyInterceptionAspectOnFullProperty = list;
            list = instance.PropertyInterceptionAspectOnFullProperty;
            instance.InterceptionAspect(list);

            CollectionAssert.AreEqual(list, excpected);
        }

        [TestMethod]
        public void PropertyAndMethod_PropertyAnnotatedWithPropertyInterceptionAspectAndMethodAnnotatedWithOnMethodBoundaryAspectOrderedJoinPointsAnnotations_ReturnsTheCorrectInterceptionAspectSequenceOfAdvices() {
            var list = new List<AspectJoinPoints>();
            var instance = container.Resolve<IMethodsAndPropertiesSubjectsComposite>();
            var excpected = new PropertyInterceptionAspectOrderedJoinPoints();

            excpected.AddRange(new OnMethodBoundaryAspectOrderedJoinPoints());
            instance.PropertyInterceptionAspectOnFullProperty = list;
            list = instance.PropertyInterceptionAspectOnFullProperty;
            instance.OnMethodBoundaryAspect(list);

            CollectionAssert.AreEqual(list, excpected);
        }
    }
}