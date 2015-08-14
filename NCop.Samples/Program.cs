using System;
using System.Diagnostics;
using System.Reflection;
using NCop.Aspects.Engine;
using NCop.Aspects.Extensions;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples
{
    internal static class Aspects
    {
        public static EventStopWatchAspect stopWatchAspect = null;

        static Aspects() {
            stopWatchAspect = new EventStopWatchAspect();
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IPerson : IDeveloper
    {
    }

    public interface IDeveloper
    {
        [MethodInterceptionAspect(typeof(StopWatchAspect))]
        void Do();

        //string CodeProp { get; set; }

        //[EventInterceptionAspect(typeof(EventStopWatchAspect))]
        event Action Code;
        void RaiseEvent();
    }

    public interface IDo
    {
        void Do();
    }

    public class CSharpDeveloperMixin : IDeveloper
    {
        //[EventInterceptionAspect(typeof(EventStopWatchAspect))]
        public event Action Code;


        //[PropertyInterceptionAspect(typeof(PropertyStopWatchAspect))]
        //public string CodeProp { get; set; }

        public void RaiseEvent() {
            if (Code != null) {
                Code();
            }
        }

        public void Do() {
        }
    }

    public class StopWatchAspect : FunctionInterceptionAspect<string>
    {
        private readonly Stopwatch stopWatch = null;

        public StopWatchAspect() {
            stopWatch = new Stopwatch();
        }

        public override void OnInvoke(FunctionInterceptionArgs<string> args) {
            stopWatch.Restart();
            base.OnInvoke(args);
            stopWatch.Stop();
            Console.WriteLine("Elapsed Ticks: {0}", stopWatch.ElapsedTicks);
        }
    }

    public class PropertyStopWatchAspect : PropertyInterceptionAspect<string>
    {
        public PropertyStopWatchAspect() {

        }

        public override void OnGetValue(PropertyInterceptionArgs<string> args) {
            base.OnGetValue(args);
        }

        public override void OnSetValue(PropertyInterceptionArgs<string> args) {
            base.OnSetValue(args);
        }
    }

    public class EventStopWatchAspect : EventActionInterceptionAspect
    {
        private readonly Stopwatch stopWatch = new Stopwatch();

        public override void OnAddHandler(EventActionInterceptionArgs args) {
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventActionInterceptionArgs args) {
            stopWatch.Restart();
            args.ProceedInvokeHandler();
            stopWatch.Stop();
            Console.WriteLine("Elapsed Ticks: {0}", stopWatch.ElapsedTicks);
        }

        public override void OnRemoveHandler(EventActionInterceptionArgs args) {
            args.ProceedRemoveHandler();
        }
    }

    class Program
    {
        static void Main(string[] args) {
            //var code = new Person().Code;
            IPerson developer = null;
            var container = new CompositeContainer();

            container.Configure();
            developer = container.Resolve<IPerson>();
            developer.Do();
        }
    }
}