using NCop.Aspects.Framework;
using System;

namespace NCop.Samples.MultipleAspects.Events
{
    public class EventInterceptionAspect : EventActionInterceptionAspect<string>
    {
        public override void OnAddHandler(EventActionInterceptionArgs<string> args) {
            Console.WriteLine("OnAddHandler of EventInterceptionAspect");
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventActionInterceptionArgs<string> args) {
            Console.WriteLine("OnInvokeHandler of EventInterceptionAspect");
            args.ProceedInvokeHandler();
        }

        public override void OnRemoveHandler(EventActionInterceptionArgs<string> args) {
            Console.WriteLine("OnRemoveHandler of EventInterceptionAspect");
            args.ProceedRemoveHandler();
        }
    }
}
