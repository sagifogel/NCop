using NCop.Aspects.Framework;
using System;
using System.Diagnostics;

namespace NCop.Samples.MethodInterceptionAspect.FunctionInterceptionAspect
{
    public class StopwatchInterceptionAspect : FunctionInterceptionAspect<string, string>
    {
        private readonly Stopwatch stopwatch = null;

        public StopwatchInterceptionAspect() {
            stopwatch = new Stopwatch();
        }

        public override void OnInvoke(FunctionInterceptionArgs<string, string> args) {
            stopwatch.Restart();
            args.Proceed();
            stopwatch.Stop();
            Console.WriteLine("Arg1: {0}", args.Arg1);
            Console.WriteLine("Return Value: {0}", args.ReturnValue);
            Console.WriteLine("Elapsed Ticks: {0}", stopwatch.ElapsedTicks);
        }
    }
}
