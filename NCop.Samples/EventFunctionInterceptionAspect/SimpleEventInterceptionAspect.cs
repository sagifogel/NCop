using NCop.Aspects.Framework;
using System;

namespace NCop.Samples.EventFunctionInterceptionAspect
{
    public class SimpleEventInterceptionAspect : EventFunctionInterceptionAspect<string>
    {
        public override void OnAddHandler(EventFunctionInterceptionArgs<string> args) {
            Console.WriteLine("OnAddHandler {0}", args.Event.Name);
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventFunctionInterceptionArgs<string> args) {
            Console.WriteLine("OnInvokeHandler {0}", args.Event.Name);
            args.ProceedInvokeHandler();
            Console.WriteLine("ReturnValue {0}", args.ReturnValue);
        }

        public override void OnRemoveHandler(EventFunctionInterceptionArgs<string> args) {
            Console.WriteLine("OnRemoveHandler {0}", args.Event.Name);
            args.ProceedRemoveHandler();
        }
    }
}
