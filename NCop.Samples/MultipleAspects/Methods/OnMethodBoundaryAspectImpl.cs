using NCop.Aspects.Framework;
using System;

namespace NCop.Samples.MultipleAspects.Methods
{
    public class OnMethodBoundaryAspectImpl : OnActionBoundaryAspect
    {
        public override void OnEntry(ActionExecutionArgs args) {
            Console.WriteLine("OnEntry");
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs args) {
            Console.WriteLine("OnSuccess");
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs args) {
            Console.WriteLine("OnException");
            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs args) {
            Console.WriteLine("OnExit");
            base.OnExit(args);
        }
    }
}
