using NCop.Aspects.Framework;
using System;
using System.Diagnostics;

namespace NCop.Samples.MethodInterceptionAspect.ActionInterceptionAspect
{
    public class StopwatchInterceptionAspect : ActionInterceptionAspect<string>
    {
        private readonly Stopwatch stopwatch = null;

        public StopwatchInterceptionAspect() {
            stopwatch = new Stopwatch();
        }

        public override void OnInvoke(ActionInterceptionArgs<string> args) {
            stopwatch.Restart();
            args.Proceed();
            stopwatch.Stop();
            Console.WriteLine("Arg1: {0}", args.Arg1);
            Console.WriteLine("Elapsed Ticks: {0}", stopwatch.ElapsedTicks);
        }
    }
}
