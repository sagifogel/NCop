using NCop.Aspects.Framework;
using System;

namespace NCop.Samples.MultipleAspects.Events
{
    public class AnotherEventInterceptionAspect : EventActionInterceptionAspect<string>
    {
        public override void OnAddHandler(EventActionInterceptionArgs<string> args) {
            Console.WriteLine("OnAddHandler of AnotherEventInterceptionAspect");
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventActionInterceptionArgs<string> args) {
            Console.WriteLine("OnInvokeHandler of AnotherEventInterceptionAspect");
            args.ProceedInvokeHandler();
        }

        public override void OnRemoveHandler(EventActionInterceptionArgs<string> args) {
            Console.WriteLine("OnRemoveHandler of AnotherEventInterceptionAspect");
            args.ProceedRemoveHandler();
        }
    }
}
