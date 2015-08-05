using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests.EventFunctionWith1ArgumentAspect.Subjects
{
    public interface IEventFunctionWith1ArgumentBoundaryAspect
    {
        event Func<List<AspectJoinPoints>, string> InterceptionAspect;
        string RaiseInterceptionAspect(List<AspectJoinPoints> args);
    }

    public class Mixin : IEventFunctionWith1ArgumentBoundaryAspect
    {
        public event Func<List<AspectJoinPoints>, string> InterceptionAspect;

        public string RaiseInterceptionAspect(List<AspectJoinPoints> args) {
            return InterceptionAspect(args);
        }
    }

    //[TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IEventFunctionWith1ArgumentComposite : IEventFunctionWith1ArgumentBoundaryAspect
    {
        [EventInterceptionAspect(typeof(FunctionEventInterceptionAspect))]
        new event Func<List<AspectJoinPoints>, string> InterceptionAspect;
    }

    public class FunctionEventInterceptionAspect : EventFunctionInterceptionAspect<List<AspectJoinPoints>, string>
    {
        public override void OnAddHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>, string> args) {
            args.ReturnValue += AspectJoinPoints.OnAddEvent.ToString();
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            args.ReturnValue += AspectJoinPoints.OnInvoke.ToString();
            args.ProceedInvokeHandler();
        }

        public override void OnRemoveHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnRemoveEvent);
            args.ReturnValue += AspectJoinPoints.OnRemoveEvent.ToString();
            args.ProceedRemoveHandler();
        }
    }
}
