using NCop.Aspects.Framework;
using System;

namespace NCop.Samples.EventActionInterceptionAspect
{
    public class SimpleEventInterceptionAspect : EventActionInterceptionAspect<string>
    {
        public override void OnAddHandler(EventActionInterceptionArgs<string> args) {
            //Console.WriteLine("OnAddHandler {0}", args.Event.Name);
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventActionInterceptionArgs<string> args) {
            //Console.WriteLine("OnInvokeHandler {0}", args.Event.Name);
            Console.WriteLine("Arg1: {0}", args.Arg1);
            args.ProceedInvokeHandler();
        }

        public override void OnRemoveHandler(EventActionInterceptionArgs<string> args) {
            Console.WriteLine("OnRemoveHandler {0}", args.Event.Name);
            args.ProceedRemoveHandler();
        }
    }
}
