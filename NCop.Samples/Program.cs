using System;
using System.Diagnostics;
using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Composite.Runtime;
using NCop.Mixins.Framework;
using StructureMap;

namespace NCop.Samples
{
    [TransientComposite]
    [Mixins(typeof(GuitarPlayerMixin), typeof(CSharpDeveloperMixin))]
    public interface IPerson : IDeveloper, IMusician
    {
    }

    public interface IDeveloper
    {
        [MethodInterceptionAspect(typeof(StopwatchInterceptionAspect))]
        void Code();
    }

    public class StopwatchInterceptionAspect : ActionInterceptionAspect
    {
        private readonly Stopwatch stopwatch = null;

        public StopwatchInterceptionAspect() {
            stopwatch = new Stopwatch();
        }

        public override void OnInvoke(ActionInterceptionArgs args) {
            stopwatch.Restart();
            base.OnInvoke(args);
            stopwatch.Stop();
            Console.WriteLine("Elapsed Ticks: {0}", stopwatch.ElapsedTicks);
        }
    }

    public interface IMusician
    {
        void Play();
    }

    [Named("GuitarPlayerMixin")]
    public class GuitarPlayerMixin : IMusician
    {
        public void Play() {
            Console.WriteLine("Playing C# accord with Fender Telecaster");
        }
    }

    public interface ITest
    {

    }

    public class TestImpl : ITest
    {

    }

    [IgnoreRegistrationAttribute]
    public class CSharpDeveloperMixin : IDeveloper
    {
        private readonly ITest test = null;

        public CSharpDeveloperMixin(TestImpl test) {
            this.test = test;
        }

        public void Code() {
            Console.WriteLine("C# coding");
        }
    }

    class Program
    {
        static void Main(string[] args) {
            var smContainer = ObjectFactory.Container;
            var settings = new CompositeRuntimeSettings {
                DependencyContainerAdapter = new StructureMapAdapter(smContainer)
            };

            IPerson person = null;
            var container = new CompositeContainer(settings);

            container.Configure();

            smContainer.Configure(x => {
                x.For<ITest>().Use<TestImpl>();
                x.For<IDeveloper>().Use<CSharpDeveloperMixin>();
            });

            person = container.Resolve<IPerson>();
            person.Code();
            person.Play();
        }
    }
}