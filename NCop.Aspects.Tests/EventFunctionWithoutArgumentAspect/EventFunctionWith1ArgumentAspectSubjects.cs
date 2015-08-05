using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests.EventFunctionWithoutArgumentAspect.Subjects
{
    public interface IEventFunctionWithoutArgumentAspect
    {
        event Func<List<AspectJoinPoints>> InterceptionAspect;
        List<AspectJoinPoints> RaiseInterceptionAspect();
    }

    public class Mixin : IEventFunctionWithoutArgumentAspect
    {
        public event Func<List<AspectJoinPoints>> InterceptionAspect;

        public List<AspectJoinPoints> RaiseInterceptionAspect() {
            return InterceptionAspect();
        }
    }

    //[TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IEventFunctionWithoutArgumentAspectComposite : IEventFunctionWithoutArgumentAspect
    {
        [EventInterceptionAspect(typeof(FunctionEventInterceptionAspect))]
        new event Func<List<AspectJoinPoints>> InterceptionAspect;
    }

    public class FunctionEventInterceptionAspect : EventFunctionInterceptionAspect<List<AspectJoinPoints>>
    {
        private List<AspectJoinPoints> aspectJoinPoints = new List<AspectJoinPoints>();

        public override void OnAddHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>> args) {
            aspectJoinPoints.Add(AspectJoinPoints.OnAdd);
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>> args) {
            args.ReturnValue.Add(AspectJoinPoints.OnInvoke);
            args.ProceedInvokeHandler();
            args.ReturnValue = aspectJoinPoints;
        }

        public override void OnRemoveHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>> args) {
            aspectJoinPoints.Add(AspectJoinPoints.OnRemove);
            args.ProceedRemoveHandler();
        }
    }
}
