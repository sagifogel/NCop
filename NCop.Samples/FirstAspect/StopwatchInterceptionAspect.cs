using NCop.Aspects.Framework;
using System;
using System.Diagnostics;

namespace NCop.Samples.FirstAspect
{
    public class StopwatchInterceptionAspect : ActionInterceptionAspect
    {
        private readonly Stopwatch stopwatch = null;

        public StopwatchInterceptionAspect() {
            stopwatch = new Stopwatch();
        }

        public override void OnInvoke(ActionInterceptionArgs args) {
            stopwatch.Restart();
            args.Proceed();
            stopwatch.Stop();
            Console.WriteLine("{0} OnSuccess", args.Method.Name);
            Console.WriteLine("Elapsed Ticks: {0}", stopwatch.ElapsedTicks);
        }
    }
}
