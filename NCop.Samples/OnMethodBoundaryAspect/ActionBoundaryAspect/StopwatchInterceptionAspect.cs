using NCop.Aspects.Framework;
using System;
using System.Diagnostics;

namespace NCop.Samples.OnMethodBoundaryAspect.ActionBoundaryAspect
{
    public class StopwatchMethodBoundaryAspect : OnActionBoundaryAspect
    {
        private readonly Stopwatch stopwatch = null;

        public StopwatchMethodBoundaryAspect() {
            stopwatch = new Stopwatch();
        }

        public override void OnEntry(ActionExecutionArgs args) {
            Console.WriteLine("{0} OnEntry", args.Method.Name);
            stopwatch.Restart();
        }

        public override void OnException(ActionExecutionArgs args) {
            Console.WriteLine("{0} OnException", args.Method.Name);
        }

        public override void OnExit(ActionExecutionArgs args) {
            Console.WriteLine("{0} OnExit", args.Method.Name);
        }

        public override void OnSuccess(ActionExecutionArgs args) {
            stopwatch.Stop();
            Console.WriteLine("{0} OnSuccess", args.Method.Name);
            Console.WriteLine("Elapsed Ticks: {0}", stopwatch.ElapsedTicks);
        }
    }
}
