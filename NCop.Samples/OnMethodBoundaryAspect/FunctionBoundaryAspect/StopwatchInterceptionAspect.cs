using NCop.Aspects.Framework;
using System;
using System.Diagnostics;

namespace NCop.Samples.OnMethodBoundaryAspect.FunctionBoundaryAspect
{
    public class StopwatchMethodBoundaryAspect : OnFunctionBoundaryAspect<string>
    {
        private readonly Stopwatch stopwatch = null;

        public StopwatchMethodBoundaryAspect() {
            stopwatch = new Stopwatch();
        }

        public override void OnEntry(FunctionExecutionArgs<string> args) {
            Console.WriteLine("{0} OnEntry", args.Method.Name);
            stopwatch.Restart();
        }

        public override void OnException(FunctionExecutionArgs<string> args) {
            Console.WriteLine("{0} OnException", args.Method.Name);
        }

        public override void OnExit(FunctionExecutionArgs<string> args) {
            Console.WriteLine("{0} OnExit", args.Method.Name);
        }

        public override void OnSuccess(FunctionExecutionArgs<string> args) {
            stopwatch.Stop();
            Console.WriteLine("{0} OnSuccess", args.Method.Name);
            Console.WriteLine("Elapsed Ticks: {0}", stopwatch.ElapsedTicks);
            Console.WriteLine("Return value: {0}", args.ReturnValue);
        }
    }
}
