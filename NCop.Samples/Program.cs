using System;
using System.Diagnostics;
using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IPerson : IDeveloper
    {
    }

    public interface IDeveloper
    {
        string Code { get; }

        void Do();
    }

    public class CSharpDeveloperMixin : IDeveloper
    {
        [PropertyInterceptionAspect(typeof(PropertyStopWatchAspect))]
        public string Code {
            //[GetPropertyInterceptionAspect(typeof(PropertyStopWatchAspect))]
            get {
                return "C#";
            }
        }

        [MethodInterceptionAspect(typeof(StopWatchAspect))]
        public void Do() {

        }
    }

    public class PropertyStopWatchAspect : PropertyInterceptionAspect<string>
    {
        public override void OnGetValue(PropertyInterceptionArgs<string> args) {
            base.OnGetValue(args);
        }

        public override void OnSetValue(PropertyInterceptionArgs<string> args) {
            base.OnSetValue(args);
        }
    }

    public class StopWatchAspect : ActionInterceptionAspect
    {
        private readonly Stopwatch stopWatch = null;

        public StopWatchAspect() {
            stopWatch = new Stopwatch();
        }

        public override void OnInvoke(ActionInterceptionArgs args) {
            stopWatch.Restart();
            base.OnInvoke(args);
            stopWatch.Stop();
            Console.WriteLine("Elapsed Ticks: {0}", stopWatch.ElapsedTicks);
        }
    }

    class Program
    {
        static void Main(string[] args) {
            IPerson developer = null;
            var container = new CompositeContainer();

            container.Configure();
            developer = container.Resolve<IPerson>();
            developer.Do();
        }
    }
}